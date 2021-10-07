using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CommerceBankWebApp.Areas.Identity.Data;
using CommerceBankWebApp.Data;
using CommerceBankWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CommerceBankWebApp.Areas.Identity.Pages.Account.Manage
{
    public class BankAccountsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CommerceBankWebAppUser> _userManager;
        public List<BankAccount> BankAccounts { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public string[] AccountTypes = new[] { "Checking", "Savings" };

        public BankAccountsModel(ApplicationDbContext context, UserManager<CommerceBankWebAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Gets BankAccount's associated with the user and stores list in the public property BankAccounts
        private async Task ReadAccounts()
        {
            // get the current user and use the user id to make a query for all associated bank accounts, store in BankAccounts
            var user = await _userManager.GetUserAsync(User);

            BankAccounts = await _context.BankAccounts.Where(b => b.CommerceBankWebAppUserId == user.Id).ToListAsync();

        }

        public class InputModel
        {
            [Required(ErrorMessage = "Account number is required!")]
            public long AccountNumber { get; set; }
            [Required(ErrorMessage = "Account type is required!")]
            public string AccountType { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Read users bank accounts from database
            await ReadAccounts();

            return Page();
        }

        // this page Post's when a user tries to add a bank account.
        public async Task<IActionResult> OnPostAsync()
        {
            // Read users bank accounts from database
            await ReadAccounts();

            // if the user didnt input valid data into the form, return to the page, displaying error messages
            if (!ModelState.IsValid) return Page();


            // if there are already bankaccounts in the system with that number, return to the page without doing anything
            // TODO: Show an error message or something!
            if ((await _context.BankAccounts.Where(b => b.AccountNumber == Input.AccountNumber).ToListAsync()).Count() != 0)
            {

                return Page();
            } else
            {
                // if the account doesnt exist lets create it

                // get users info
                var user = await _userManager.GetUserAsync(User);

                // create an account using the form data the user supplied
                BankAccount account = new BankAccount()
                {
                    AccountNumber = Input.AccountNumber,
                    AccountType = Input.AccountType,
                    CommerceBankWebAppUserId = user.Id
                };

                // add the account to the database and save changes
                _context.BankAccounts.Attach(account);
                await _context.SaveChangesAsync();
            }
            // re-read accounts associated with this user from the database, and display the page
            // If everything went well the new account should be among the accounts read
            await ReadAccounts();
            return Page();
        }
    }
}