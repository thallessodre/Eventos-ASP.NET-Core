#pragma checksum "C:\Users\Thalles\Desktop\Arquivos\Projetos\ASP NET Core\Eventos.IO\src\Eventos.IO.Site\Views\Erros\Forbidden.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "783b3d2fc1e44066ac2c5d33cb571f1647cf67f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Erros_Forbidden), @"mvc.1.0.view", @"/Views/Erros/Forbidden.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Erros/Forbidden.cshtml", typeof(AspNetCore.Views_Erros_Forbidden))]
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
#line 1 "C:\Users\Thalles\Desktop\Arquivos\Projetos\ASP NET Core\Eventos.IO\src\Eventos.IO.Site\Views\_ViewImports.cshtml"
using Eventos.IO.Infra.CrossCutting.Identity.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"783b3d2fc1e44066ac2c5d33cb571f1647cf67f0", @"/Views/Erros/Forbidden.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67eef7c5acc98e936d00a0f9f94de83f3d134576", @"/Views/_ViewImports.cshtml")]
    public class Views_Erros_Forbidden : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Thalles\Desktop\Arquivos\Projetos\ASP NET Core\Eventos.IO\src\Eventos.IO.Site\Views\Erros\Forbidden.cshtml"
  
    ViewData["Title"] = "Proibido";

#line default
#line hidden
            BeginContext(44, 40, true);
            WriteLiteral("\r\n<header>\r\n    <h1 class=\"text-danger\">");
            EndContext();
            BeginContext(85, 17, false);
#line 6 "C:\Users\Thalles\Desktop\Arquivos\Projetos\ASP NET Core\Eventos.IO\src\Eventos.IO.Site\Views\Erros\Forbidden.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(102, 108, true);
            WriteLiteral("</h1>\r\n    <p class=\"text-danger\">Você está tentanto acessar um recurso de acesso proibido.</p>\r\n</header>\r\n");
            EndContext();
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
