#pragma checksum "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\Notifications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b65039ae49043726cd59038e62b54ca3b3c5e009"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Notifications), @"mvc.1.0.razor-page", @"/Pages/Notifications.cshtml")]
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
#line 3 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\Notifications.cshtml"
using CommerceBankWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b65039ae49043726cd59038e62b54ca3b3c5e009", @"/Pages/Notifications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"802e1a1175cac27322427e0a3ca600797f722b55", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Notifications : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\Notifications.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Notifications";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"<div class=""row"">
    <div style=""margin: 0 auto;"" class=""col white-block btn-margin-20 round-corners"">
        <table class=""table"">
            <tr>
                <td>Account #</td>
                <td>Date</td>
                <td>Message</td>
            </tr>
");
#nullable restore
#line 20 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\Notifications.cshtml"
              
            foreach (Notification notification in Model.Notifications)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\Notifications.cshtml"
               Write(notification.BankAccount.AccountNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\Notifications.cshtml"
               Write(notification.DateProcessed.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\Notifications.cshtml"
               Write(notification.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 29 "C:\Users\alexn\source\test\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\Notifications.cshtml"
            }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CommerceBankWebApp.Areas.Identity.Pages.Account.NotificationsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CommerceBankWebApp.Areas.Identity.Pages.Account.NotificationsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CommerceBankWebApp.Areas.Identity.Pages.Account.NotificationsModel>)PageContext?.ViewData;
        public CommerceBankWebApp.Areas.Identity.Pages.Account.NotificationsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591