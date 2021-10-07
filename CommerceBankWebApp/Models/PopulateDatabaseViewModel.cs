using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceBankWebApp.Models
{
    public class PopulateDatabaseViewModel
    {
        public List<BankAccount> BankAccounts { get; set; }


        [BindProperty]
        // the file that the user uploads
        public IFormFile Upload { get; set; }

        public async Task ReadExcelData(System.IO.Stream file)
        {

            // create a spread sheet light document using the file provided
            SLDocument document = new SLDocument(file);

            // get a list of all work sheets in the excel file
            var workSheets = document.GetSheetNames();

            // for each sheet in the document i.e. "Cust A", "Cust B"
            // TODO: Crashes on invalid files
            foreach (var sheet in workSheets)
            {
                // select the sheet
                document.SelectWorksheet(sheet);

                // get statistics about the document i.e. number of rows, cols, etc.
                SLWorksheetStatistics stats = document.GetWorksheetStatistics();

                // for each row (1 indexed. We start with row 2 because the first row is the headings)
                for (short row = 2; row <= stats.EndRowIndex; row++)
                {
                    // data we intend to read from the curent row

                    string accountType = "Checking"; // default to Checking, but if data is provided in the excel sheet, can be changed.
                    long? accountNumber = null;
                    DateTime? processingDate = null;
                    double? balance = null;
                    bool? isCredit = null;
                    double? amount = null;
                    string description = null;

                    // for every column in the current row
                    for (short col = 1; col <= 8; col++)
                    {
                        // if there is no value, skip it
                        if (!document.HasCellValue(row, col)) continue;

                        // Find out what the column header is (first row column j)
                        // and use that column header to figure out what to do with data in the current cell
                        // TODO: HANDLE BAD DATA
                        switch (document.GetCellValueAsString(1, col))
                        {
                            case "Account Type":
                                accountType = document.GetCellValueAsString(row, col);
                                break;
                            case "Acct #":
                                accountNumber = document.GetCellValueAsInt64(row, col);
                                break;
                            case "Processing Date":
                                processingDate = document.GetCellValueAsDateTime(row, col);
                                break;
                            case "Balance":
                                balance = document.GetCellValueAsDouble(row, col);
                                break;
                            case "CR (Deposit) or DR (Withdrawal":
                            case "CR (Deposit) or DR (Withdrawal)":
                                string cellText = document.GetCellValueAsString(row, col);

                                if (cellText == "CR") isCredit = true;
                                else isCredit = false;
                                break;
                            case "Amount":
                                amount = document.GetCellValueAsDouble(row, col);
                                break;
                            case "Description 1":
                                description = document.GetCellValueAsString(row, col);
                                break;
                        }
                    }

                    // if the data contains an account number and a date, we got something to work with
                    if (accountNumber.HasValue && processingDate.HasValue)
                    {
                        // bank account we are accessing will be stored here
                        BankAccount bankAccount;

                        // query for bank accounts matching the number
                        var query = BankAccounts.Where(ac => ac.AccountNumber == accountNumber.Value).ToList();

                        // if we didnt find any matching account numbers in the database, make a new account
                        if (!query.Any())
                        {
                            // if no balance was specified use 0.0
                            if (!balance.HasValue) balance = 0.0;

                            // We will create a new bank account of balance 0.0, then create a deposit with the transaction amount equal to balance
                            isCredit = true; // so set isCredit to true
                            amount = balance.Value; // and the amount to balance (our initial balance)

                            // create the new bank account
                            bankAccount = new BankAccount()
                            {
                                AccountNumber = accountNumber.Value,
                                AccountType = accountType,
                                Balance = 0.0,
                                Transactions = new List<Transaction>()
                            };

                            BankAccounts.Add(bankAccount);

                            // if no description was provided, use (initial starting balance) for the first transactiond description
                            if (String.IsNullOrEmpty(description)) description = "(initial starting balance)";
                        }
                        else
                        {
                            // if there was a bank account with the account number already in the database, set bankAcount to that one
                            bankAccount = query.First();
                        }

                        // if the transaction has an ammount and we know whether its a credit or withdrawal (we already know its got an acct# and date)
                        if (amount.HasValue && isCredit.HasValue)
                        {
                            // if the account type doesnt match the account type of the existing account log a warning
                            if (accountType != bankAccount.AccountType)
                            {
                                //_logger.LogWarning($"Account type wrong. Account exists already with type: {accountType} but excel data claims type {bankAccount.AccountType}");
                            }

                            if (String.IsNullOrEmpty(description)) description = "No description";

                            // create a new transaction using data
                            // (some of this data may have been modified above if this was the first transaction under this acct#)
                            Transaction transaction = new Transaction()
                            {
                                ProcessingDate = processingDate.Value,
                                IsCredit = isCredit.Value,
                                Amount = amount.Value,
                                Description = description
                            };

                            // Add the transaction to the database
                            bankAccount.Transactions.Add(transaction);
                            if (transaction.IsCredit) bankAccount.Balance += transaction.Amount;
                            else bankAccount.Balance -= transaction.Amount;
                        }
                    }
                }
            }

        }
    }
}
