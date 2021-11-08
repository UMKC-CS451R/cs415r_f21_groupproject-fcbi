﻿using CommerceBankWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceBankWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AccountHolder> AccountHolders { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<BankAccountType> BankAccountTypes { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // this code makes AccountNumbers unique. We can not have accounts with the same account number
            builder.Entity<BankAccount>()
                .HasIndex(b => b.AccountNumber)
                .IsUnique();
        }

        public List<BankAccount> GetAllBankAccounts()
        {
            return BankAccounts
                .Include(ac => ac.BankAccountType)
                .ToList();
        }

        public List<BankAccount> GetAllBankAccountsWithTransactions()
        {
            return BankAccounts
                .Include(ac => ac.BankAccountType)
                .Include(ac => ac.Transactions)
                .ThenInclude(t => t.TransactionType)
                .ToList();
        }

        public List<BankAccount> GetAllBankAccountsFromUser(string userId)
        {
            var accounts = new List<BankAccount>();
            try
            {
                var accountHolder = AccountHolders.Where(ach => ach.WebAppUserId == userId).FirstOrDefault();

                accounts = BankAccounts.Where(b => b.AccountHolderId == accountHolder.Id)
                        .Include(ac => ac.BankAccountType).ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error finding account");
            }
            return accounts;
        }

        public List<BankAccount> GetAllBankAccountsFromUserWithTransactions(string userId)
        {
            var accountHolder = AccountHolders.Where(ach => ach.WebAppUserId == userId).FirstOrDefault();
            var accounts = BankAccounts.Where(b => b.AccountHolderId == accountHolder.Id)
                    .Include(ac => ac.BankAccountType)
                    .Include(ac => ac.Transactions)
                    .ThenInclude(t => t.TransactionType).ToList();
            return accounts;
        }

        public BankAccount GetBankAccountByAccountNumber(string accountNumber)
        {
            return BankAccounts.Where(ac => ac.AccountNumber == accountNumber)
                .Include(ac => ac.BankAccountType)
                .SingleOrDefault();
        }

        public BankAccount GetBankAccountByAccountNumberWithTransactions(string accountNumber)
        {
            return BankAccounts.Where(ac => ac.AccountNumber == accountNumber)
                .Include(ac => ac.BankAccountType)
                .Include(ac => ac.Transactions)
                .ThenInclude(t => t.TransactionType)
                .SingleOrDefault();
        }
        public void RegisterNewAccountHolder(AccountHolder accountHolder)
        {
            AccountHolders.Add(accountHolder);
            SaveChanges();
        }

        public void AddTransaction(Transaction transaction)
        {
            var bankAccount = BankAccounts.Find(transaction.BankAccountId);

            if (bankAccount == null)
            {
                throw new Exception("Invalid account. Cannot add transaciton!");
            }

            if (transaction.TransactionType == TransactionType.Deposit)
            {
                bankAccount.Balance += transaction.Amount;

            } else if (transaction.TransactionType == TransactionType.Withdrawal)
            {
                bankAccount.Balance -= transaction.Amount;
            }

            BankAccounts.Update(bankAccount);
            Transactions.Add(transaction);
            SaveChanges();
        }
    }
}
