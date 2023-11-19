#pragma checksum "D:\HutechDonation\Views\History\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f00e5640664f51ee4a1cb00abe13283159d929570ae3c9bbb2801336b49503ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_History_Index), @"mvc.1.0.view", @"/Views/History/Index.cshtml")]
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
#line 1 "D:\HutechDonation\Views\_ViewImports.cshtml"
using Web_Donation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\HutechDonation\Views\_ViewImports.cshtml"
using Web_Donation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f00e5640664f51ee4a1cb00abe13283159d929570ae3c9bbb2801336b49503ae", @"/Views/History/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"3c7d3a9f4b4b66da23302a8f485589bd55151f10e7a959c72529f96f8f5c535e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_History_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Web_Donation.Models.CombinedViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\HutechDonation\Views\History\Index.cshtml"
  
    ViewData["Title"] = "Block Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\HutechDonation\Views\History\Index.cshtml"
  
    var pagedBlockDetails = Model.PagedBlockDetailsList;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section>
    <div class=""container border-3"" >

        <div class=""row"" style=""padding-top: 50px; display: flex; justify-content: center; align-items: center;"">
            <h1>LỊCH SỬ ỦNG HỘ</h1>
        </div>
        <div class=""row mt-4"">
            <div class=""col-1""></div>
            
");
#nullable restore
#line 20 "D:\HutechDonation\Views\History\Index.cshtml"
             foreach (var filteredBlockViewModel in Model.FilteredBlockViewModelList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-3 border-top border-bottom \">\r\n                    <h4>");
#nullable restore
#line 23 "D:\HutechDonation\Views\History\Index.cshtml"
                   Write(filteredBlockViewModel.Product_ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <span class=\"balance\" style=\"display: inline-block; font-size: 20px\">");
#nullable restore
#line 24 "D:\HutechDonation\Views\History\Index.cshtml"
                                                                                    Write(string.Format("{0:N0} VNĐ", filteredBlockViewModel.TotalAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <!-- Add logic to display filtered blocks if needed -->\r\n");
#nullable restore
#line 27 "D:\HutechDonation\Views\History\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n             \r\n            <div class=\"col-1\">\r\n                <h4>Tổng</h4>\r\n                <span class=\"balance\" style=\"display: inline-block; font-size: 20px\">");
#nullable restore
#line 32 "D:\HutechDonation\Views\History\Index.cshtml"
                                                                                Write(string.Format("{0:N0} VNĐ", ViewBag.Balance));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
            </div>
          
            <div class=""col-1""></div>
        </div>
        <div class=""mt-4""></div>
        <div class=""row"">
            <div class=""col-1""></div>
            <div class=""col-10 border"">
                <table class=""table table-striped"">
                    <thead>
                        <tr>
                            <th scope=""col"" style=""text-align: center""><h4>STT</h4></th>
                            <th scope=""col"" style=""text-align: center""><h4>Nội dung</h4></th>
                           
                        </tr>
                    </thead>
                        <tbody>
");
#nullable restore
#line 50 "D:\HutechDonation\Views\History\Index.cshtml"
                             foreach (var blockDetail in pagedBlockDetails)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                <td class=\"center-vertical\" style=\"text-align: center\"><h5>");
#nullable restore
#line 53 "D:\HutechDonation\Views\History\Index.cshtml"
                                                                                      Write(blockDetail.Index);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5></td>\r\n                                <td>\r\n                                        <p><strong>Họ tên:</strong> ");
#nullable restore
#line 55 "D:\HutechDonation\Views\History\Index.cshtml"
                                                               Write(blockDetail.NameSender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <p><strong>Ngày giao dịch:</strong> ");
#nullable restore
#line 56 "D:\HutechDonation\Views\History\Index.cshtml"
                                                                       Write(blockDetail.Timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <p><strong>Số tiền:</strong> ");
#nullable restore
#line 57 "D:\HutechDonation\Views\History\Index.cshtml"
                                                            Write(string.Format("{0:N0} VNĐ", blockDetail.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <p><strong>Nội dung:</strong> ");
#nullable restore
#line 58 "D:\HutechDonation\Views\History\Index.cshtml"
                                                                 Write(blockDetail.TransactionDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <p><strong>Previous Hash:</strong> ");
#nullable restore
#line 59 "D:\HutechDonation\Views\History\Index.cshtml"
                                                                      Write(blockDetail.PreviousHash);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <p><strong>Hash:</strong> ");
#nullable restore
#line 60 "D:\HutechDonation\Views\History\Index.cshtml"
                                                             Write(blockDetail.Hash);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 63 "D:\HutechDonation\Views\History\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                </table>\r\n            </div>\r\n            <div class=\"col-1\"></div>\r\n            <div class=\"mb-4\"></div>\r\n        </div>\r\n        <div class=\"pagination\">\r\n");
#nullable restore
#line 71 "D:\HutechDonation\Views\History\Index.cshtml"
             if (Model.PagedBlockDetailsList.HasPreviousPage)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a href=\"?page=1\">First</a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 3235, "\"", 3293, 2);
            WriteAttributeValue("", 3242, "?page=", 3242, 6, true);
#nullable restore
#line 74 "D:\HutechDonation\Views\History\Index.cshtml"
WriteAttributeValue("", 3248, Model.PagedBlockDetailsList.PageNumber - 1, 3248, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Previous</a>\r\n");
#nullable restore
#line 75 "D:\HutechDonation\Views\History\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "D:\HutechDonation\Views\History\Index.cshtml"
             for (var i = 1; i <= Model.PagedBlockDetailsList.PageCount; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 3436, "\"", 3451, 2);
            WriteAttributeValue("", 3443, "?page=", 3443, 6, true);
#nullable restore
#line 78 "D:\HutechDonation\Views\History\Index.cshtml"
WriteAttributeValue("", 3449, i, 3449, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 3452, "\"", 3522, 1);
#nullable restore
#line 78 "D:\HutechDonation\Views\History\Index.cshtml"
WriteAttributeValue("", 3460, i == Model.PagedBlockDetailsList.PageNumber ? "active" : "", 3460, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 78 "D:\HutechDonation\Views\History\Index.cshtml"
                                                                                                     Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 79 "D:\HutechDonation\Views\History\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "D:\HutechDonation\Views\History\Index.cshtml"
             if (Model.PagedBlockDetailsList.HasNextPage)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 3639, "\"", 3697, 2);
            WriteAttributeValue("", 3646, "?page=", 3646, 6, true);
#nullable restore
#line 82 "D:\HutechDonation\Views\History\Index.cshtml"
WriteAttributeValue("", 3652, Model.PagedBlockDetailsList.PageNumber + 1, 3652, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Next</a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 3727, "\"", 3778, 2);
            WriteAttributeValue("", 3734, "?page=", 3734, 6, true);
#nullable restore
#line 83 "D:\HutechDonation\Views\History\Index.cshtml"
WriteAttributeValue("", 3740, Model.PagedBlockDetailsList.PageCount, 3740, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Last</a>\r\n");
#nullable restore
#line 84 "D:\HutechDonation\Views\History\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Web_Donation.Models.CombinedViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
