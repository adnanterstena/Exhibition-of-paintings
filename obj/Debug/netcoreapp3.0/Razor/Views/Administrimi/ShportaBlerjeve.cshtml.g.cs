#pragma checksum "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\Administrimi\ShportaBlerjeve.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "442c52aeb07fa570a4fb580be8e80f9612897f91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrimi_ShportaBlerjeve), @"mvc.1.0.view", @"/Views/Administrimi/ShportaBlerjeve.cshtml")]
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
#line 1 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\_ViewImports.cshtml"
using EkspozitaPikturave;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\_ViewImports.cshtml"
using EkspozitaPikturave.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"442c52aeb07fa570a4fb580be8e80f9612897f91", @"/Views/Administrimi/ShportaBlerjeve.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7cb6592ca86e8a45fb2f0db90dac4e340e9bd7c", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrimi_ShportaBlerjeve : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EkspozitaPikturave.ViewModels.AdministrimiShportaBlerjeve>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\Administrimi\ShportaBlerjeve.cshtml"
  
    ViewData["Title"] = "Shporta";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div style=""overflow-y: scroll; height:590px; border-style:inset; padding:25px"">

    <table class=""table"">
        <thead>
            <tr>
                <th>

                </th>
                <th>
                    Titulli
                </th>
                <th>
                    Çmimi
                </th>
                <th>
                    ");
#nullable restore
#line 22 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\Administrimi\ShportaBlerjeve.cshtml"
               Write(Html.DisplayNameFor(model => model.Blerja));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\Administrimi\ShportaBlerjeve.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 834, "\"", 886, 1);
#nullable restore
#line 32 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\Administrimi\ShportaBlerjeve.cshtml"
WriteAttributeValue("", 840, Html.DisplayFor(modelItem => item.urlPiktura), 840, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"50\" width=\"50\" />\r\n\r\n                    </td>\r\n                    <td class=\"align-middle\">\r\n                        <b>");
#nullable restore
#line 36 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\Administrimi\ShportaBlerjeve.cshtml"
                      Write(Html.DisplayFor(modelItem => item.titulliPiktures));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                    </td>\r\n                    <td class=\"align-middle\">\r\n                        ");
#nullable restore
#line 39 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\Administrimi\ShportaBlerjeve.cshtml"
                   Write(Html.DisplayFor(modelItem => item.cmimi));

#line default
#line hidden
#nullable disable
            WriteLiteral(" €\r\n                    </td>\r\n                    <td style=\"color:darkblue\" class=\"align-middle\">\r\n                        ");
#nullable restore
#line 42 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\Administrimi\ShportaBlerjeve.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Blerja));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 45 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\Administrimi\ShportaBlerjeve.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EkspozitaPikturave.ViewModels.AdministrimiShportaBlerjeve>> Html { get; private set; }
    }
}
#pragma warning restore 1591
