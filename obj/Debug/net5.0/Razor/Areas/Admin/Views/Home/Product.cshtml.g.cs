#pragma checksum "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2456c3a2681c91a1d5e773bcb4bfb0769cb20ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Product), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Product.cshtml")]
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
#line 5 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
using Microsoft.AspNetCore.Http.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2456c3a2681c91a1d5e773bcb4bfb0769cb20ee", @"/Areas/Admin/Views/Home/Product.cshtml")]
    public class Areas_Admin_Views_Home_Product : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
  
    var username = Context.Session.GetString("Username");
    var userId = Context.Session.GetString("UserId");
    var role = Context.Session.GetString("Role");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 14 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
 if (role == "full")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""template-page-wrapper"">
        <div class=""navbar-collapse collapse templatemo-sidebar"">
            <ul class=""templatemo-sidebar-menu"">
                <li><a href=""#""><i class=""fa fa-home""></i>Dashboard</a></li>
                <li class=""sub open active"">
                    <a href=""javascript:;"">
                        <i class=""fa fa-database""></i> Dự án
                        <div class=""pull-right""><span class=""caret""></span></div>
                    </a>
                    <ul class=""templatemo-submenu"">
                        <li><a href=""#"">Thông tin dự án</a></li>
                        <li class=""active""><a href=""/Admin/Home/AddProduct"">Thêm dự án</a></li>
                    </ul>
                </li>

                <li class=""sub"">
                    <a href=""javascript:;"">
                        <i class=""fa fa-cubes""></i> Chi tiết dự án
                        <div class=""pull-right""><span class=""caret""></span></div>
                    </a>
  ");
            WriteLiteral(@"                  <ul class=""templatemo-submenu"">
                        <li><a href=""#"">Thêm chi tiết dự án</a></li>
                        <li><a href=""#"">Sửa chi tiết dự án</a></li>
                        <li><a href=""#"">Xóa chi tiết dự án</a></li>
                    </ul>
                </li>

                <li class=""sub "">
                    <a href=""javascript:;"">
                        <i class=""fa fa-users""></i> Quản lý tài khoản
                        <div class=""pull-right""><span class=""caret""></span></div>
                    </a>
                    <ul class=""templatemo-submenu"">
                        <li><a href=""#"">Thêm tài khoản</a></li>
                        <li><a href=""#"">Sửa thông tin tài khoản</a></li>
                        <li><a href=""#"">Xóa tài khoản</a></li>
                    </ul>
                </li>
                <li><a href=""javascript:;"" data-toggle=""modal"" data-target=""#confirmModal""><i class=""fa fa-sign-out""></i>Log Out</a></li>
        ");
            WriteLiteral(@"    </ul>
        </div>
        <!--/.navbar-collapse -->
        <div class=""templatemo-content-wrapper"">
            <div class=""templatemo-content"">
                <h2>Project List</h2>
                <table class=""table table-striped"">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Mã dự án</th>
                            <th>Tên dự án</th>
                            <th>Thông tin giới thiệu</th>
                            <th>Hình ảnh</th>
                            <th style=""width: 100px;"">Hành động</th>
                        </tr>
                    </thead>
                     <tbody>
");
#nullable restore
#line 73 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
      foreach (var project in Model)
     {

#line default
#line hidden
#nullable disable
            WriteLiteral("         <tr>\r\n             <td>");
#nullable restore
#line 76 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
            Write(project.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n             <td>");
#nullable restore
#line 77 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
            Write(project.Producid);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n             <td>");
#nullable restore
#line 78 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
            Write(project.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n             <td>");
#nullable restore
#line 79 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
            Write(project.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n             <td>");
#nullable restore
#line 80 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
            Write(project.Images);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n             <td>\r\n                <a href=\"javascript:void(0);\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3429, "\"", 3545, 15);
            WriteAttributeValue("", 3439, "editRecord(\'", 3439, 12, true);
#nullable restore
#line 82 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
WriteAttributeValue("", 3451, project.Id, 3451, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3462, "\',", 3462, 2, true);
            WriteAttributeValue(" ", 3464, "\'", 3465, 2, true);
#nullable restore
#line 82 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
WriteAttributeValue("", 3466, project.Producid, 3466, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3483, "\',", 3483, 2, true);
            WriteAttributeValue(" ", 3485, "\'", 3486, 2, true);
#nullable restore
#line 82 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
WriteAttributeValue("", 3487, project.Name, 3487, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3500, "\',", 3500, 2, true);
            WriteAttributeValue(" ", 3502, "\'", 3503, 2, true);
#nullable restore
#line 82 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
WriteAttributeValue("", 3504, project.Description, 3504, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3524, "\',", 3524, 2, true);
            WriteAttributeValue(" ", 3526, "\'", 3527, 2, true);
#nullable restore
#line 82 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
WriteAttributeValue("", 3528, project.Images, 3528, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3543, "\')", 3543, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"edit-btn\" title=\"Edit\" data-toggle=\"tooltip\" style=\"color: green;\"><i class=\"material-icons\">&#xE254;</i></a>\r\n                <a href=\"javascript:void(0);\" class=\"delete-btn\" title=\"Delete\" data-toggle=\"tooltip\" style=\"color: red;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3786, "\"", 3821, 3);
            WriteAttributeValue("", 3796, "deleteItem(\'", 3796, 12, true);
#nullable restore
#line 83 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
WriteAttributeValue("", 3808, project.Id, 3808, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3819, "\')", 3819, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">&#xE872;</i></a>\r\n\r\n                 <!-- Add action buttons here -->\r\n             </td>\r\n         </tr>\r\n");
#nullable restore
#line 88 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </tbody>
                </table>
            </div>
        </div>
    </div>
    <div class=""modal fade"" id=""editModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""editModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <form id=""editProductForm"" action=""/Admin/Home/EditProduct"" method=""post"" enctype=""multipart/form-data"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""editModalLabel"">Edit Record</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                        <input name=""editId"" type=""hidden"" id=""editId"" />
                        <label for=""editProducId"">Product ID:</label>
                        <input type=""text"" id=""editProducId"" name=""edit");
            WriteLiteral(@"ProducId"" class=""form-control"" readonly />
                        <label for=""editName"">Name:</label>
                        <input type=""text"" id=""editName"" name=""editName"" class=""form-control"" />
                        <label for=""editDescription"">Description:</label>
                        <textarea id=""editDescription"" name=""editDescription"" class=""form-control""></textarea>
                        <label for=""editImages"">Images:</label>
                        <input type=""file"" id=""ImageFile"" name=""ImageFile"" class=""form-control"" />
                    </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    <button type=""submit"" class=""btn btn-primary"">Save changes</button>
                </div>

            </div>
            </form>

        </div>
    </div>
    <!-- Modal -->
    <form id=""confirmDeleteForm"" action=""/Admin/Home/DeleteProduct"" method=""post"" enct");
            WriteLiteral(@"ype=""multipart/form-data"">
        <div class=""modal"" id=""confirmDeleteModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""confirmDeleteModalLabel"" aria-hidden=""true"">
            <div class=""modal-dialog"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""confirmDeleteModalLabel"">Xác nhận xóa</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        <p>Bạn có chắc chắn muốn xóa không?</p>
                        <!-- Thêm các trường cần thiết cho form xác nhận xóa -->
                        <input type=""hidden"" id=""itemIdToDelete"" name=""itemIdToDelete"" />
                    </div>
                    <div class=""modal-footer"">
               ");
            WriteLiteral(@"         <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Hủy</button>
                        <button type=""submit"" class=""btn btn-danger"">Xóa</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
");
            WriteLiteral(@"    <script>
        // Hàm để xử lý việc xóa
        function deleteItem(itemId) {
            // Set giá trị itemId vào trường ẩn của form
            $('#itemIdToDelete').val(itemId);

            // Hiển thị modal
            $('#confirmDeleteModal').modal('show');
        }

        // Hàm để xử lý việc gửi form xác nhận xóa
        function submitDeleteForm() {
            // Lấy giá trị từ trường ẩn của form
            var itemId = $('#itemIdToDelete').val();

            // Thực hiện các hành động xóa ở đây (sử dụng Ajax hoặc submit form trực tiếp)

            // Sau khi thực hiện xóa, đóng modal
            $('#confirmDeleteModal').modal('hide');
        }

        function editRecord(id, producId, name, description, images) {
            // Set values to the modal fields
            document.getElementById('editId').value = id;
            document.getElementById('editProducId').value = producId;
            document.getElementById('editName').value = name;
            do");
            WriteLiteral(@"cument.getElementById('editDescription').value = description;

            // Create a new file input element
            var newFileInput = document.createElement('input');
            newFileInput.type = 'file';
            newFileInput.id = 'ImageFile';
            newFileInput.name = 'ImageFile';
            newFileInput.className = 'form-control';

            // Replace the existing file input with the new one
            var oldFileInput = document.getElementById('ImageFile');
            oldFileInput.parentNode.replaceChild(newFileInput, oldFileInput);

            // Show the modal
            $('#editModal').modal('show');
        }

        
    </script>
");
#nullable restore
#line 195 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <center>
        <section>
            <div class=""container"">
                <div class=""row d-flex justify-content-center align-items-center h-100"">
                    <div class=""col-12 col-md-10 col-lg-6 col-xl-5"">
                        <div class=""card "" style=""border-radius: 1rem;"">
                            <div class=""card-body p-5"">
                                <div class=""container payment_success"">
                                    <p>
                                        <h3>Xin lỗi</h3>
                                        <h3>Bạn không có quyền truy cập vào trang này !!!</h3>
                                    </p>
                                    <p>Trang sẽ tự động chuyển về trang chủ sau <span id=""countdown"">15</span> giây</p>
                                    <a href=""/admin/home/index""> Trang chủ</a>
                                </div>

                            </div>
                        </div>
                    </div>
              ");
            WriteLiteral("  </div>\r\n            </div>\r\n        </section>\r\n    </center>\r\n");
            WriteLiteral(@"    <script>
        // Hàm để tự động chuyển hướng sau 15 giây
        function redirectToHome() {
            window.location.href = '/admin/home/index'; // Thay đổi '/home' thành URL của trang chủ của bạn
        }

        // Gọi hàm redirectToHome sau 15 giây
        let countdown = 15;
        let countdownElement = document.getElementById('countdown');

        function updateCountdown() {
            countdown--;
            countdownElement.textContent = countdown;

            if (countdown <= 0) {
                redirectToHome();
            }
        }

        setInterval(updateCountdown, 1000); // Cập nhật mỗi giây (1000 mili giây)
    </script>
");
#nullable restore
#line 245 "D:\Web-Donation\Web-Donation\Areas\Admin\Views\Home\Product.cshtml"

}

#line default
#line hidden
#nullable disable
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
