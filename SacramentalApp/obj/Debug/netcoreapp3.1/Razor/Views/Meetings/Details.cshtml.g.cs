#pragma checksum "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "065403a9398991031136bcbc0f02d59203dd93821c5c6fa7efdbe6edf6e1146c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Meetings_Details), @"mvc.1.0.view", @"/Views/Meetings/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\_ViewImports.cshtml"
using SacramentalApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\_ViewImports.cshtml"
using SacramentalApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"065403a9398991031136bcbc0f02d59203dd93821c5c6fa7efdbe6edf6e1146c", @"/Views/Meetings/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"a61d43e6847b67b5ef448973484d8ac5a2bbbee53f2321529bde04fa70f8ee5b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Meetings_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SacramentalApp.Models.Meeting>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Print", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Print"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Meeting</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ConductingLeader));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayFor(model => model.ConductingLeader));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OpeningSong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayFor(model => model.OpeningSong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OpeningPrayer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayFor(model => model.OpeningPrayer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SacramentHymn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayFor(model => model.SacramentHymn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n\r\n");
            WriteLiteral("\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 48 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Speeches));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n\r\n\r\n            <table class=\"table\">\r\n                <tr>\r\n                    <th>Speaker</th>\r\n                    <th>Topic</th>\r\n                </tr>\r\n");
#nullable restore
#line 58 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
                 foreach (var item in Model.Speeches)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 62 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NameSpeaker));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 65 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Topic));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 68 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n\r\n        </dd>\r\n\r\n");
            WriteLiteral("\r\n\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 77 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IntermediateHymn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 80 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayFor(model => model.IntermediateHymn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 83 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CloseningSong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 86 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayFor(model => model.CloseningSong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 89 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CloseningPrayer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 92 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
       Write(Html.DisplayFor(model => model.CloseningPrayer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "065403a9398991031136bcbc0f02d59203dd93821c5c6fa7efdbe6edf6e1146c14080", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 98 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
                                                   WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "065403a9398991031136bcbc0f02d59203dd93821c5c6fa7efdbe6edf6e1146c16392", async() => {
                WriteLiteral("<i class=\"fa fa-print\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 99 "D:\DOC\OneDrive - BYU-Idaho\BYU\2024_FALL_FATALITY\CSE499\sacramentMeeting\SacramentalApp\Views\Meetings\Details.cshtml"
                                                    WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "065403a9398991031136bcbc0f02d59203dd93821c5c6fa7efdbe6edf6e1146c18813", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SacramentalApp.Models.Meeting> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
