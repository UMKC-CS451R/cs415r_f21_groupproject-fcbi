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


        public async Task<List<BankAccount>> ReadBankAccountsCurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);

             return await _context.BankAccounts.Where(ac => ac.CommerceBankWebAppUserId == user.Id).Include(ac => ac.Transactions).ToListAsync();
        }

        public async Task<List<BankAccount>> ReadBankAccountsAllUsers()
        {
            var user = await _userManager.GetUserAsync(User);

            return await _context.BankAccounts.Include(ac => ac.Transactions).ToListAsync();
        }

        public async Task<IActionResult> ViewTransactions()
        {
            List<BankAccount> bankAccounts;

            if (User.IsInRole("admin"))
            {
                bankAccounts = await ReadBankAccountsAllUsers();
            } else
            {
                bankAccounts = await ReadBankAccountsCurrentUser();
            }

            ViewTransactionsViewModel model = new ViewTransactionsViewModel();

            model.BankAccounts = bankAccounts;

            return View(model);
        }

        public async Task<IActionResult> AddTransaction()
        {
            List<BankAccount> bankAccounts;

            if (User.IsInRole("admin"))
            {
                bankAccounts = await ReadBankAccountsAllUsers();
            }
            else
            {
                bankAccounts = await ReadBankAccountsCurrentUser();
            }


            AddTransactionViewModel model = new AddTransactionViewModel();

            model.AccountSelectList = new List<SelectListItem>();

            model.BankAccounts = bankAccounts;

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

            _context.Transactions.Add(transaction);

            if (transaction.IsCredit) bankAccount.Balance += transaction.Amount;
            else bankAccount.Balance -= transaction.Amount;

            _context.BankAccounts.Attach(bankAccount);

            await _context.SaveChangesAsync();



            return RedirectToAction("ViewTransactions");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PopulateDatabase()
        {
            List<BankAccount> accounts = await _context.BankAccounts.Include( ac => ac.Transactions).ToListAsync();

            PopulateDatabaseViewModel model = new PopulateDatabaseViewModel();

            model.BankAccounts = accounts;

            await _context.SaveChangesAsync();

            return View(model);
        }

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
