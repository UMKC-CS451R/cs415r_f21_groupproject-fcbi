#pragma checksum "D:\Documents\School\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a1c5cc68c8ec2582bcce4b7c1a06d7218dcbf40"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Privacy), @"mvc.1.0.razor-page", @"/Pages/Privacy.cshtml")]
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
#line 1 "D:\Documents\School\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\_ViewImports.cshtml"
using CommerceBankWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Documents\School\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\_ViewImports.cshtml"
using CommerceBankWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Documents\School\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a1c5cc68c8ec2582bcce4b7c1a06d7218dcbf40", @"/Pages/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"802e1a1175cac27322427e0a3ca600797f722b55", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Privacy : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Documents\School\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\Privacy.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Privacy Policy";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 style=\"text-align:center;\">");
#nullable restore
#line 9 "D:\Documents\School\cs415r_f21_groupproject-fcbi\CommerceBankWebApp\Pages\Privacy.cshtml"
                          Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

<div class=""text-box"" style=""text-align:center;"">
    <div>Protecting your privacy is important to Commerce and to our employees. We want you to understand what information we collect and how we use it. Our Privacy Statement serves as a standard for all Commerce employees for collection, use, retention and security of nonpublic personal information.</div>
    <br>
    <p><a href=""https://www.commercebank.com/-/media/cb/pdf/global/privacy-statement.pdf?la=en&revision=f458c008-5c48-477f-90a5-b2c57506c56c&modified=20200130133411&hash=E7AD01524CEC88B30AD0208FCBD7F7F6B7D5E271"" target=""_blank"">Privacy Statement <sup>[PDF]</sup></a></p>
    <br>
    <p>
        <strong>Disclosures</strong><br>
        To view or print a PDF file, Adobe?? Reader?? 9.5 or above is recommended. <a href=""https://get.adobe.com/reader/"">Download the latest version</a>.
    </p>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CommerceBankWebApp.Pages.PrivacyModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CommerceBankWebApp.Pages.PrivacyModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CommerceBankWebApp.Pages.PrivacyModel>)PageContext?.ViewData;
        public CommerceBankWebApp.Pages.PrivacyModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
