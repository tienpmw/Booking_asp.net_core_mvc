#pragma checksum "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4cc332a92633150b7e016382f47208385ed46269"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bookings_Index), @"mvc.1.0.view", @"/Views/Bookings/Index.cshtml")]
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
#line 1 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\_ViewImports.cshtml"
using SE1617_Group4_A3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\_ViewImports.cshtml"
using SE1617_Group4_A3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cc332a92633150b7e016382f47208385ed46269", @"/Views/Bookings/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"456b6bb833b05c5077393a95633706aa39e6921f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Bookings_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SE1617_Group4_A3.Models.Booking>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
  
    ViewData["Title"] = "Booking";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Booking</h1>\r\n\r\n\r\n<div id=\"box-seats\">\r\n");
#nullable restore
#line 10 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
      
        int count = 0;
        for (int i = 0; i < (ViewBag.Room as Room).NumberRows; i++)
        {
            for (int j = 0; j < (ViewBag.Room as Room).NumberCols; j++)
            {
                foreach (char[] item in (ViewBag.listBooked as List<char[]>))
                {
                    if (item[count] == '1')
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input type=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 541, "\"", 557, 1);
#nullable restore
#line 20 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
WriteAttributeValue("", 549, count, 549, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" checked disabled />\r\n");
#nullable restore
#line 21 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input type=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 698, "\"", 714, 1);
#nullable restore
#line 24 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
WriteAttributeValue("", 706, count, 706, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled />\r\n");
#nullable restore
#line 25 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
                    }
                }
                count++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br />\r\n");
#nullable restore
#line 30 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 33 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
Write(Html.ActionLink("Create New Booking", "Create", "Bookings", new { id = @Model.BookingId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>The number of booking: ");
#nullable restore
#line 34 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
                       Write((ViewBag.listBooking as List<Booking>).Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 35 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
  
    if (TempData["message"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div id=\"success-alert\" class=\"alert alert-success alert-dismissible fade in\">\r\n            <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>\r\n            <strong>Success!</strong> ");
#nullable restore
#line 40 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
                                 Write(TempData["message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 42 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
 if ((ViewBag.listBooking as List<Booking>).Count != 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 50 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n");
            WriteLiteral("                <th>\r\n                    ");
#nullable restore
#line 56 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 62 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
             foreach (Booking item in (ViewBag.listBooking as List<Booking>))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 66 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 72 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 75 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", "Bookings", new { idBooking = item.BookingId, idShow = @Model.BookingId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 76 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", "Bookings", new { idBooking = item.BookingId, idShow = @Model.BookingId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 77 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", "Bookings", new { idBooking = item.BookingId, idShow = @Model.BookingId }, new { @class = "delete" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 80 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 84 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 87 "E:\PRN211\AS3\SE1617_Group4_A3\SE1617_Group4_A3\Views\Bookings\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("    <script>\r\n        $(\"#success-alert\").fadeTo(2000, 500).slideUp(500, function () {\r\n            $(\"#success-alert\").slideUp(500);\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SE1617_Group4_A3.Models.Booking> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591