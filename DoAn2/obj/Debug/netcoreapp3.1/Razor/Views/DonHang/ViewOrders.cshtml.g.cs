#pragma checksum "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13f8b409f23333b31f76bf0cc5feaa5f7b668e1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DonHang_ViewOrders), @"mvc.1.0.view", @"/Views/DonHang/ViewOrders.cshtml")]
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
#line 1 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\_ViewImports.cshtml"
using DoAn2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\_ViewImports.cshtml"
using DoAn2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13f8b409f23333b31f76bf0cc5feaa5f7b668e1e", @"/Views/DonHang/ViewOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df00a4cbbe4191a747c7dde25833609a59e65ba4", @"/Views/_ViewImports.cshtml")]
    public class Views_DonHang_ViewOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script>
    $(function () {
        $('a[name=""print""]').click(function () {
            var pageTitle = 'Hóa dơn đặt hàng',
                stylesheet = '//maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css',
                win = window.open('', 'Print', 'width=900,height=600');
            win.document.write('<html><head><title>' + pageTitle + '</title>' +
                '<link rel=""stylesheet"" href=""' + stylesheet + '"">' +
                '</head><body>' + $('.table')[0].outerHTML + '</body></html>');
            win.document.close();
            win.print();
            return false;
        });
    });
</script>
<a class=""btn-ttmh"" name=""print"" style=""color: #5666a5;"">In hóa đơn</a>
<table class=""table"" id=""myTable"" class=""display"" style=""width:100%"">
    <thead>
        <tr style=""color:crimson"">
            <th>STT</th>
            <th>Mã đơn hàng</th>
            <th>Tên sản phẩm</th>
            <th>Số lượng</th>
            <th>Thành tiền</th>
        </tr>
   ");
            WriteLiteral(" </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml"
         foreach (var item in ViewBag.Orders)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("id", " id=\"", 1243, "\"", 1260, 2);
            WriteAttributeValue("", 1248, "row_", 1248, 4, true);
#nullable restore
#line 33 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml"
WriteAttributeValue("", 1252, item.Id, 1252, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <td>");
#nullable restore
#line 34 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml"
               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 35 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml"
               Write(item.Or_transaction_id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 36 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml"
               Write(item.Or_product_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 37 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml"
               Write(item.Or_qty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml"
               Write(item.Or_price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 40 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<hr />  \r\n");
#nullable restore
#line 44 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml"
 foreach (var item in @ViewBag.totalPrice)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("  <h3><span style=\"float: left;\">Tổng tiền</span><b><span style=\"float: right; margin-right: 100px;\">");
#nullable restore
#line 46 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml"
                                                                                                Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></b></h3>\r\n");
#nullable restore
#line 47 "C:\Users\User\Downloads\DoAn2\DoAn2\DoAn2\Views\DonHang\ViewOrders.cshtml"
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
