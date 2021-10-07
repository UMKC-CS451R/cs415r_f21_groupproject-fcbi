using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceBankWebApp.Models
{
    public class AddTransactionViewModel
    {
        public List<SelectListItem> AccountSelectList { get; set; }
        public List<BankAccount> BankAccounts { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Account Number")]
            public long AccountNumber { get; set; }

            [Required]
            [Display(Name = "Date Processed")]
            [DataType(DataType.Date)]
            public DateTime ProcessingDate { get; set; }

            [Required]
            [Display(Name = "Credit")]
            public bool IsCredit { get; set; }

            [Required]
            [Display(Name = "Amount")]
            [DataType(DataType.Currency)]
            public double Amount { get; set; }

            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; }
        }
    }
}
