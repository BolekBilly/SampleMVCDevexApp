#pragma checksum "C:\Users\bmuzalewski\Desktop\PROJEKTY\013 Zadanie_MVC\SampleMVCDevexApp\SampleMVCDevexApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c1a2389a6065f728a7ee694a043eac4672644b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\bmuzalewski\Desktop\PROJEKTY\013 Zadanie_MVC\SampleMVCDevexApp\SampleMVCDevexApp\Views\_ViewImports.cshtml"
using SampleMVCDevexApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\bmuzalewski\Desktop\PROJEKTY\013 Zadanie_MVC\SampleMVCDevexApp\SampleMVCDevexApp\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\bmuzalewski\Desktop\PROJEKTY\013 Zadanie_MVC\SampleMVCDevexApp\SampleMVCDevexApp\Views\Home\Index.cshtml"
using SampleMVCDevexApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c1a2389a6065f728a7ee694a043eac4672644b3", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff515f65dddfc675a6e69493245b98611ca900ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Home</h2>\r\n\r\n");
#nullable restore
#line 5 "C:\Users\bmuzalewski\Desktop\PROJEKTY\013 Zadanie_MVC\SampleMVCDevexApp\SampleMVCDevexApp\Views\Home\Index.cshtml"
Write(Html.DevExtreme().DataGrid().ID("gridTest")
	.ShowBorders(true)
	.DataSource(d => d.Mvc()
		.Controller("SampleData")
		.LoadAction("GetTestData")
		.InsertAction("InsertTestData")
		.UpdateAction("UpdateTestData")
		.DeleteAction("DeleteTestData")
		.Key("Id"))
	.Columns(columns => {
		columns.Add().DataField("Id"); //.AllowEditing(false);
		columns.Add().DataField("FirstName");
		columns.Add().DataField("LastName");
		columns.Add().DataField("Description");
		columns.Add().DataField("Department");
		columns.Add().DataField("Office");
		columns.Add().DataField("Phone");
		columns.Add().DataField("Email");

	//z��czenie imienia z nazwiskiem, ale nie wiem jak potem takie pole dodawa� do bazy...
		
		//columns.Add().DataField("Active").DataType(GridColumnDataType.Boolean);
	})
	.Editing(e =>
	{
		e.AllowAdding(true);
		e.AllowUpdating(true);
		e.AllowDeleting(true);
		e.UseIcons(true);
	})
	.Paging(p => p.PageSize(50))
	.FilterRow(f => f.Visible(true))
	.HeaderFilter(f => f.Visible(true))
	.GroupPanel(p => p.Visible(true))
	.Grouping(g => g.AutoExpandAll(true)) //by�o false...
	.RemoteOperations(true)
	.AllowColumnResizing(true)
	.AllowColumnReordering(true)
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
