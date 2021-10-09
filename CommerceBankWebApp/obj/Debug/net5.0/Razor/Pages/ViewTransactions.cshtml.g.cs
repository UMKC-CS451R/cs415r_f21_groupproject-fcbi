#pragma checksum "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2efbda8adac8045b65a126c8af8b072d072bd89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_ViewTransactions), @"mvc.1.0.razor-page", @"/Pages/ViewTransactions.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\_ViewImports.cshtml"
using CommerceBankWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\_ViewImports.cshtml"
using CommerceBankWebApp.Areas.Identity.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
using CommerceBankWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/ViewTransactions/{index:int?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2efbda8adac8045b65a126c8af8b072d072bd89", @"/Pages/ViewTransactions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82d1ac9c08f7b471316c760949328f50fd13f3ec", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ViewTransactions : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 7 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Add Transaction";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 13 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
 if (Model.AccountToDisplay == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1 style=\"text-align: center\">Select Account To Display</h1>\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div style=\"text-align: center; margin: 0 auto\" class=\"col-md-4 btn-margin-20 white-block round-corners btn-block\">\r\n");
#nullable restore
#line 19 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                 for (int i = 0; i < Model.BankAccounts.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a style=\"color: white;\" class=\"green-block round-corners btn btn-margin-20\"");
            BeginWriteAttribute("href", " href=", 769, "", 808, 1);
#nullable restore
#line 21 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
WriteAttributeValue("", 775, $"/ViewTransactions?index={i}", 775, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 21 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                                                                                                                                   Write(Model.BankAccounts[i].AccountType);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ( ");
#nullable restore
#line 21 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                                                                                                                                                                        Write(Model.BankAccounts[i].AccountNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ) </a>\r\n                    <br />\r\n");
#nullable restore
#line 23 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 27 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
}
else
{


#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table"">
        <tr>
            <td>Account Type</td>
            <td>Account #</td>
            <td>Date</td>
            <td>Balance</td>
            <td>Credit or Withdrawal</td>
            <td>Amount</td>
            <td>Description</td>
        </tr>
");
#nullable restore
#line 41 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
          
            double balance = 0.0;

            foreach (Transaction transaction in Model.AccountToDisplay.Transactions)
            {

                if (transaction.IsCredit) balance += transaction.Amount;
                else balance -= transaction.Amount;


#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 51 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                   Write(Model.AccountToDisplay.AccountType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 52 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                   Write(Model.AccountToDisplay.AccountNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 53 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                   Write(transaction.ProcessingDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 54 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                     if (balance < 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"text-danger\">$");
#nullable restore
#line 56 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                                            Write(balance.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 57 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>$");
#nullable restore
#line 60 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                        Write(balance.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 61 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 63 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                     if (transaction.IsCredit)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"text-success\">CR</td>\r\n                        <td class=\"text-success\">$");
#nullable restore
#line 66 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                                             Write(transaction.Amount.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 67 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"text-danger\">DR</td>\r\n                        <td>$");
#nullable restore
#line 71 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                        Write(transaction.Amount.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 72 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <td>");
#nullable restore
#line 74 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
                   Write(transaction.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 76 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 79 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\ViewTransactions.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<CommerceBankWebAppUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<CommerceBankWebAppUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CommerceBankWebApp.Pages.ViewTransactionsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CommerceBankWebApp.Pages.ViewTransactionsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CommerceBankWebApp.Pages.ViewTransactionsModel>)PageContext?.ViewData;
        public CommerceBankWebApp.Pages.ViewTransactionsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591