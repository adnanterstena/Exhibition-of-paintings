#pragma checksum "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\WebPikturat\PikturatBallina.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f199f3653d6c5cd9aa19b9b136936b4e8e1000d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WebPikturat_PikturatBallina), @"mvc.1.0.view", @"/Views/WebPikturat/PikturatBallina.cshtml")]
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
#nullable restore
#line 1 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\WebPikturat\PikturatBallina.cshtml"
using ReflectionIT.Mvc.Paging;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f199f3653d6c5cd9aa19b9b136936b4e8e1000d8", @"/Views/WebPikturat/PikturatBallina.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7cb6592ca86e8a45fb2f0db90dac4e340e9bd7c", @"/Views/_ViewImports.cshtml")]
    public class Views_WebPikturat_PikturatBallina : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private global::AspNetCore.Views_WebPikturat_PikturatBallina.__Generated__PagerViewComponentTagHelper __PagerViewComponentTagHelper;
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "WebPikturat", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Ballina", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<br />\r\n<center><h1 style=\"color:dimgrey\">Më të rejat</h1></center>\r\n<div style=\"text-align:center\">\r\n    <table style=\"display:inline-block\">\r\n        <tbody>\r\n            <tr style=\"padding-top:25px\">\r\n");
#nullable restore
#line 9 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\WebPikturat\PikturatBallina.cshtml"
                 for (int i = 0; i < ViewBag.PikturatBallina.Count; i++)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <td>
                        <div style=""font-family:'Comic Sans MS', cursive, sans-serif; background-color:whitesmoke; padding:15px; width:285px"">

                            <div style=""height:330px"">
                                <center><h3> <b>");
#nullable restore
#line 16 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\WebPikturat\PikturatBallina.cshtml"
                                           Write(ViewBag.PikturatBallina[i].TitulliPiktures);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h3></center>\r\n                                <div style=\"text-align:center\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 815, "\"", 857, 1);
#nullable restore
#line 18 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\WebPikturat\PikturatBallina.cshtml"
WriteAttributeValue("", 822, ViewBag.PikturatBallina[i].UrlPath, 822, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-size=\"1600x1067\">\r\n                                        <img alt=\"picture\"");
            BeginWriteAttribute("src", " src=\"", 941, "\"", 982, 1);
#nullable restore
#line 19 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\WebPikturat\PikturatBallina.cshtml"
WriteAttributeValue("", 947, ViewBag.PikturatBallina[i].UrlPath, 947, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=275 style=\"max-width: 100%\" class=\"figure-img\">\r\n                                    </a>\r\n                                </div>\r\n                            </div>\r\n                            <center> <p>");
#nullable restore
#line 23 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\WebPikturat\PikturatBallina.cshtml"
                                   Write(ViewBag.PikturatBallina[i].DataPostimit);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p> </center>\r\n                        </div>\r\n                    </td>\r\n");
#nullable restore
#line 26 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\WebPikturat\PikturatBallina.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n<br />\r\n<div class=\"float-lg-left\" style=\"padding-left:45px; color:white\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f199f3653d6c5cd9aa19b9b136936b4e8e1000d87983", async() => {
                WriteLiteral("Kthehu te Ballina");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<nav aria-label=\"Pikturat navigation example\" class=\"float-lg-right\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f199f3653d6c5cd9aa19b9b136936b4e8e1000d89729", async() => {
            }
            );
            __PagerViewComponentTagHelper = CreateTagHelper<global::AspNetCore.Views_WebPikturat_PikturatBallina.__Generated__PagerViewComponentTagHelper>();
            __tagHelperExecutionContext.Add(__PagerViewComponentTagHelper);
#nullable restore
#line 36 "C:\Users\adnan\source\repos\EkspozitaPikturave\EkspozitaPikturave\Views\WebPikturat\PikturatBallina.cshtml"
__PagerViewComponentTagHelper.pagingList = ViewBag.PikturatBallina;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("paging-list", __PagerViewComponentTagHelper.pagingList, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</nav>\r\n\r\n<br />\r\n<br />");
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
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute("vc:pager")]
        public class __Generated__PagerViewComponentTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
        {
            private readonly global::Microsoft.AspNetCore.Mvc.IViewComponentHelper __helper = null;
            public __Generated__PagerViewComponentTagHelper(global::Microsoft.AspNetCore.Mvc.IViewComponentHelper helper)
            {
                __helper = helper;
            }
            [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBoundAttribute, global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContextAttribute]
            public global::Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }
            public ReflectionIT.Mvc.Paging.IPagingList pagingList { get; set; }
            public override async global::System.Threading.Tasks.Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput __output)
            {
                (__helper as global::Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware)?.Contextualize(ViewContext);
                var __helperContent = await __helper.InvokeAsync("Pager", new { pagingList });
                __output.TagName = null;
                __output.Content.SetHtmlContent(__helperContent);
            }
        }
    }
}
#pragma warning restore 1591
