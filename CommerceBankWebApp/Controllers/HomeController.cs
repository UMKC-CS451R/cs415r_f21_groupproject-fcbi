using CommerceBankWebApp.Areas.Identity.Data;
using CommerceBankWebApp.Data;
using CommerceBankWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceBankWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CommerceBankWebAppUser> _userManager;
        private readonly SignInManager<CommerceBankWebAppUser> _signInManager;


        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext context,
            UserManager<CommerceBankWebAppUser> userManager,
            SignInManager<CommerceBankWebAppUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // returns a list of all bank accounts associated with the current user
        public async Task<List<BankAccount>> ReadBankAccountsCurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);

             return await _context.BankAccounts.Where(ac => ac.CommerceBankWebAppUserId == user.Id).Include(ac => ac.Transactions).ToListAsync();
        }

        // returns a list of all bank accounts in the database
        public async Task<List<BankAccount>> ReadBankAccountsAllUsers()
        {
            return await _context.BankAccounts.Include(ac => ac.Transactions).ToListAsync();
        }

        // View for viewing transactions
        public async Task<IActionResult> ViewTransactions()
        {
            // if we are admin, get list of all bank accounts, otherwise just the accounts owned by the user
            List<BankAccount> bankAccounts;

            if (User.IsInRole("admin"))
            {
                bankAccounts = await ReadBankAccountsAllUsers();
            } else
            {
                bankAccounts = await ReadBankAccountsCurrentUser();
            }

            // create the page model for the view, and store the bank accounts in it
            ViewTransactionsViewModel model = new ViewTransactionsViewModel();

            model.BankAccounts = bankAccounts;

            return View(model);
        }


        // View for adding a transaction
        public async Task<IActionResult> AddTransaction()
        {
            // if we are admin, get list of all bank accounts, otherwise just the accounts owned by the user
            List<BankAccount> bankAccounts;

            if (User.IsInRole("admin"))
            {
                bankAccounts = await ReadBankAccountsAllUsers();
            }
            else
            {
                bankAccounts = await ReadBankAccountsCurrentUser();
            }

            // create the page model for the view, and store the bank accounts in it
            AddTransactionViewModel model = new AddTransactionViewModel();
            model.BankAccounts = bankAccounts;

            // the page has a drop down menu. Populate the list with names of accounts that the user can add the transaction to
            model.AccountSelectList = new List<SelectListItem>();

            foreach (BankAccount account in model.BankAccounts)
            {
                model.AccountSelectList.Add(new SelectListItem()
                {
                    Text = $"{account.AccountNumber} -- {account.AccountType}",
                    Value = account.AccountNumber.ToString()
                });
            }

            return View(model);
        }

        // The add transaction page posts when a user tries to add an account
        [HttpPost]
        public async Task<IActionResult> AddTransaction(AddTransactionViewModel model)
        {
            // if the data given isn't valid return to the page and display errors
            if (!ModelState.IsValid) return View(model);

            // TODO: Security flaw. If the user modifies post data, could inject data into other accounts
            var query = _context.BankAccounts.Where(ac => ac.AccountNumber == model.Input.AccountNumber).ToList();

            BankAccount bankAccount = query.First();

            // create a new transaction assocated with this bank account
            Transaction transaction = new Transaction()
            {
                BankAccount = bankAccount,
                Amount = model.Input.Amount,
                ProcessingDate = model.Input.ProcessingDate,
                IsCredit = model.Input.IsCredit,
                Description = model.Input.Description
            };

            // add the transaciton to the database
            _context.Transactions.Add(transaction);

            // update the bank account balance
            if (transaction.IsCredit) bankAccount.Balance += transaction.Amount;
            else bankAccount.Balance -= transaction.Amount;

            // update the bank account data in the db and save changes
            _context.BankAccounts.Attach(bankAccount);
            await _context.SaveChangesAsync();

            // redirect to the view transactions page
            return RedirectToAction("ViewTransactions");
        }

        // Only admins can view this page
        // this view lets the user upload an excel file to populate transactions into the database
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PopulateDatabase()
        {
            // read all bank accounts in the database
            List<BankAccount> bankAccounts = await ReadBankAccountsAllUsers();

            // create the view model and store the accounts in it
            PopulateDatabaseViewModel model = new PopulateDatabaseViewModel();
            model.BankAccounts = bankAccounts;

            return View(model);
        }

        // The add transaction page posts when a user tries to add an account
        // It posts when the user has uploaded a file
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> PopulateDatabase(PopulateDatabaseViewModel model)
        {
            List<BankAccount> bankAccounts = await ReadBankAccountsAllUsers();

            model.BankAccounts = bankAccounts;

            model.ReadExcelData(model.Upload.OpenReadStream());

            _context.BankAccounts.AttachRange(model.BankAccounts);

            await _context.SaveChangesAsync();

            return RedirectToAction("ViewTransactions");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
