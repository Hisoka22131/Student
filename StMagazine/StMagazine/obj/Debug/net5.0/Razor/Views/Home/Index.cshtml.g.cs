#pragma checksum "C:\Users\dimak\source\repos\StMagazine\StMagazine\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f04f2eae0754c36f2d874495fd085f3d7c0ec5e3"
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
#line 1 "C:\Users\dimak\source\repos\StMagazine\StMagazine\Views\_ViewImports.cshtml"
using StMagazine;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\dimak\source\repos\StMagazine\StMagazine\Views\Home\Index.cshtml"
using StMagazine.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f04f2eae0754c36f2d874495fd085f3d7c0ec5e3", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4121edd252d89cff324af56c748cbd8fd81f17b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\dimak\source\repos\StMagazine\StMagazine\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Журнал студентов";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .round {
        width: 300px;
        height: auto; /* Ширина и высота */
        margin: 0 0 0 0 auto;
        border-radius: 50%; /* Превращаем в круг */
        background-size: auto 300px; /* Высота фотографии равна высоте элемента */
    }
</style>
<div class=""ml-5"">
    <!-- Three columns of text below the carousel -->
    <div class=""row"">
        <div class=""col-lg-4"">
            <img src=""/images/Students.jpg"" class=""round"" />
            <h2 class=""fw-normal"">Студенты</h2>
            <p><a class=""btn btn-secondary"" href=""Student/Index"">Подробнее »</a></p>
        </div><!-- /.col-lg-4 -->
        <div class=""col-lg-4"">
            <img src=""/images/Teachers.jpg"" class=""round"" />
            <h2 class=""fw-normal"">Учителя</h2>
            <p><a class=""btn btn-secondary"" href=""Teacher/Index"">Подробнее »</a></p>
        </div><!-- /.col-lg-4 -->
        <div class=""col-lg-4"">
            <img src=""/images/Groups.jpg"" class=""round"" />
            <h2 class=""fw-norma");
            WriteLiteral(@"l"">Группы</h2>
            <p><a class=""btn btn-secondary"" href=""Group/Index"">Подробнее »</a></p>
        </div><!-- /.col-lg-4 -->
        <div class=""col-lg-4"">
            <img src=""/images/Courses.jpg"" class=""round"" />
            <h2 class=""fw-normal"">Курсы</h2>
            <p><a class=""btn btn-secondary"" href=""Cours/Index"">Подробнее »</a></p>
        </div><!-- /.col-lg-4 -->
        <div class=""col-lg-4"">
            <img src=""/images/Items.jpg"" class=""round"" />
            <h2 class=""fw-normal"">Предметы</h2>
            <p><a class=""btn btn-secondary"" href=""Item/Index"">Подробнее »</a></p>
        </div><!-- /.col-lg-4 -->
    </div><!-- /.row -->
</div>

");
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
