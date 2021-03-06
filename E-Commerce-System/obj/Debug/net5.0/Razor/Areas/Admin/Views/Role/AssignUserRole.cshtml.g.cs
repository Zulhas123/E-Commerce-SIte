#pragma checksum "D:\MvcPracticeFolder\E-Commerce-System\Areas\Admin\Views\Role\AssignUserRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fd4d5fe3a8dd262634f2335313764afe38acbad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Role_AssignUserRole), @"mvc.1.0.view", @"/Areas/Admin/Views/Role/AssignUserRole.cshtml")]
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
#line 1 "D:\MvcPracticeFolder\E-Commerce-System\Areas\Admin\Views\_ViewImports.cshtml"
using E_Commerce_System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MvcPracticeFolder\E-Commerce-System\Areas\Admin\Views\_ViewImports.cshtml"
using E_Commerce_System.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fd4d5fe3a8dd262634f2335313764afe38acbad", @"/Areas/Admin/Views/Role/AssignUserRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ad939a5ccbadaf1fd5c79330ad73fb0cdfd6f32", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Role_AssignUserRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\MvcPracticeFolder\E-Commerce-System\Areas\Admin\Views\Role\AssignUserRole.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<br />\r\n<br />\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-6\">\r\n        <h2 class=\"text-info \"> User Role Mapping  </h2>\r\n    </div>\r\n\r\n");
            WriteLiteral(@"
</div>
<br />
<table class=""table table-striped border"">
    <thead>
        <tr class=""table-info"">
            <th>
                User Name
            </th>
            <th>
                Role Name
            </th>
          
        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 40 "D:\MvcPracticeFolder\E-Commerce-System\Areas\Admin\Views\Role\AssignUserRole.cshtml"
         foreach (var item in ViewBag.UserRoles)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 43 "D:\MvcPracticeFolder\E-Commerce-System\Areas\Admin\Views\Role\AssignUserRole.cshtml"
               Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 44 "D:\MvcPracticeFolder\E-Commerce-System\Areas\Admin\Views\Role\AssignUserRole.cshtml"
               Write(item.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 54 "D:\MvcPracticeFolder\E-Commerce-System\Areas\Admin\Views\Role\AssignUserRole.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n\r\n\r\n</table>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n    <script src=\"//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/alertify.min.js\"></script>\r\n\r\n    <script type=\"text/javascript\">\r\n\r\n\r\n\r\n        $(function () {\r\n            var Save = \'");
#nullable restore
#line 69 "D:\MvcPracticeFolder\E-Commerce-System\Areas\Admin\Views\Role\AssignUserRole.cshtml"
                   Write(TempData["Save"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n            if (Save != null) {\r\n                alertify.success(Save);\r\n            }\r\n\r\n            var edit = \'");
#nullable restore
#line 74 "D:\MvcPracticeFolder\E-Commerce-System\Areas\Admin\Views\Role\AssignUserRole.cshtml"
                   Write(TempData["edit"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n            if (edit != null) {\r\n                alertify.success(edit);\r\n            }\r\n\r\n            var del = \'");
#nullable restore
#line 79 "D:\MvcPracticeFolder\E-Commerce-System\Areas\Admin\Views\Role\AssignUserRole.cshtml"
                  Write(TempData["Delete"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n            if (del != null) {\r\n                alertify.success(del);\r\n            }\r\n        })\r\n\r\n\r\n    </script>\r\n");
            }
            );
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
