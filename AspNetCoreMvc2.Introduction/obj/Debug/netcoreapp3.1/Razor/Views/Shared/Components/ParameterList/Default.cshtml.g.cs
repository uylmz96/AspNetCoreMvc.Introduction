#pragma checksum "C:\Users\uylmz\source\repos\AspNetCoreMvc2.Introduction\AspNetCoreMvc2.Introduction\Views\Shared\Components\ParameterList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e1bcaa2d9db4805a733f607ebdfa35c84020916"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ParameterList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ParameterList/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e1bcaa2d9db4805a733f607ebdfa35c84020916", @"/Views/Shared/Components/ParameterList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd3ff9c262f3bd5cfb478b4b89a9b591eaf5ca6e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ParameterList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AspNetCoreMvc2.Introduction.DataSources.Models.ParameterListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\uylmz\source\repos\AspNetCoreMvc2.Introduction\AspNetCoreMvc2.Introduction\Views\Shared\Components\ParameterList\Default.cshtml"
 foreach (var item in Model.Parameters)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 6 "C:\Users\uylmz\source\repos\AspNetCoreMvc2.Introduction\AspNetCoreMvc2.Introduction\Views\Shared\Components\ParameterList\Default.cshtml"
Write(String.Format("{0} - {1}", item.Key, item.Value));

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\uylmz\source\repos\AspNetCoreMvc2.Introduction\AspNetCoreMvc2.Introduction\Views\Shared\Components\ParameterList\Default.cshtml"
                                                     
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AspNetCoreMvc2.Introduction.DataSources.Models.ParameterListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
