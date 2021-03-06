using CommerceBankWebApp.Data;
using CommerceBankWebApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceBankWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetService<UserManager<IdentityUser>>();
                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                var ruleChecker = services.GetRequiredService<NotificationRuleCheck>();

                // if the database doesnt exist, create it
                context.Database.EnsureCreated();

                if (!context.BankAccountTypes.Any())
                {
                    context.BankAccountTypes.Add(BankAccountType.Checking);
                    context.BankAccountTypes.Add(BankAccountType.Savings);
                }

                if (!context.TransactionTypes.Any())
                {
                    context.TransactionTypes.Add(TransactionType.Deposit);
                    context.TransactionTypes.Add(TransactionType.Withdrawal);
                }

                // Create an admin user if there is none
                EnsureAdminCreated(userManager, roleManager).Wait();

                // save changes to database
                context.SaveChanges();
            }
            host.Run();
        }

        // this function checks if the admin user has been created, and if not creates it
        // TODO: Admin's user name and password are hard coded into this file. Would be better to store in a secrets file in the future for security!
        private static async Task EnsureAdminCreated(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // look for an existing user with the username fcbiadmin@fcbi.com
            var user = await userManager.FindByNameAsync("fcbiadmin@fcbi.com");

            // if there was no such user, create one and add it to the database
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "fcbiadmin@fcbi.com",
                    EmailConfirmed = true,
                };

                await userManager.CreateAsync(user, "Wifokato68!"); // create user with password Wifokato68
            }

            // if there is no administratory role (users can be given this role to have admin priveleges)
            if (!await roleManager.RoleExistsAsync("admin"))
            {
                // create the admin role and add the admin role to the administrator account
                await roleManager.CreateAsync(new IdentityRole("admin"));
                await userManager.AddToRoleAsync(user, "admin");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
