#pragma checksum "C:\EMIAspNetCoreTraining\EMIAspNetCore\Asp.netCoreMVC\Asp.netCoreMVC\Views\Employees\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e324dc8f6f9cfed46ff1d5b1e5736174d0a54e4c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_Index), @"mvc.1.0.view", @"/Views/Employees/Index.cshtml")]
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
#line 1 "C:\EMIAspNetCoreTraining\EMIAspNetCore\Asp.netCoreMVC\Asp.netCoreMVC\Views\_ViewImports.cshtml"
using Asp.netCoreMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\EMIAspNetCoreTraining\EMIAspNetCore\Asp.netCoreMVC\Asp.netCoreMVC\Views\_ViewImports.cshtml"
using Asp.netCoreMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e324dc8f6f9cfed46ff1d5b1e5736174d0a54e4c", @"/Views/Employees/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfe38933644d5b7c63ce67c3120522fd6815c810", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\EMIAspNetCoreTraining\EMIAspNetCore\Asp.netCoreMVC\Asp.netCoreMVC\Views\Employees\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n\r\n<table border=\"1\" cellpadding=\"3\">\r\n    <tr>\r\n        <th>EmployeeId</th>\r\n        <th>Name</th>\r\n        <th>Location</th>\r\n        <th>Department</th>\r\n    </tr>\r\n");
#nullable restore
#line 16 "C:\EMIAspNetCoreTraining\EMIAspNetCore\Asp.netCoreMVC\Asp.netCoreMVC\Views\Employees\Index.cshtml"
     foreach(var i in (List<Employee>) ViewBag.employeeDetails)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 19 "C:\EMIAspNetCoreTraining\EMIAspNetCore\Asp.netCoreMVC\Asp.netCoreMVC\Views\Employees\Index.cshtml"
           Write(i.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 20 "C:\EMIAspNetCoreTraining\EMIAspNetCore\Asp.netCoreMVC\Asp.netCoreMVC\Views\Employees\Index.cshtml"
           Write(i.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 21 "C:\EMIAspNetCoreTraining\EMIAspNetCore\Asp.netCoreMVC\Asp.netCoreMVC\Views\Employees\Index.cshtml"
           Write(i.location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "C:\EMIAspNetCoreTraining\EMIAspNetCore\Asp.netCoreMVC\Asp.netCoreMVC\Views\Employees\Index.cshtml"
           Write(i.department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 24 "C:\EMIAspNetCoreTraining\EMIAspNetCore\Asp.netCoreMVC\Asp.netCoreMVC\Views\Employees\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
