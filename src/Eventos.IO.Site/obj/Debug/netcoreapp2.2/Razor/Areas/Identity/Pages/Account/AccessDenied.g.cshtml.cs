#pragma checksum "C:\Users\Thalles\Desktop\Arquivos\Projetos\ASP NET Core\Eventos.IO\src\Eventos.IO.Site\Areas\Identity\Pages\Account\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "166d64360a0ea1d6fc8886cebb80f22f4d95fd6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Eventos.IO.Site.Areas.Identity.Pages.Account.Areas_Identity_Pages_Account_AccessDenied), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/AccessDenied.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/Identity/Pages/Account/AccessDenied.cshtml", typeof(Eventos.IO.Site.Areas.Identity.Pages.Account.Areas_Identity_Pages_Account_AccessDenied), null)]
namespace Eventos.IO.Site.Areas.Identity.Pages.Account
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Thalles\Desktop\Arquivos\Projetos\ASP NET Core\Eventos.IO\src\Eventos.IO.Site\Areas\Identity\Pages\_ViewImports.cshtml"
using Eventos.IO.Site.Areas.Identity;

#line default
#line hidden
#line 2 "C:\Users\Thalles\Desktop\Arquivos\Projetos\ASP NET Core\Eventos.IO\src\Eventos.IO.Site\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 1 "C:\Users\Thalles\Desktop\Arquivos\Projetos\ASP NET Core\Eventos.IO\src\Eventos.IO.Site\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Eventos.IO.Site.Areas.Identity.Pages.Account;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"166d64360a0ea1d6fc8886cebb80f22f4d95fd6c", @"/Areas/Identity/Pages/Account/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4755e8447152fd1f8ac094935f1a3ae793a6ffb8", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22b8d8851c17bd5c5f8f8a83ace44356f2af3bcb", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_AccessDenied : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Thalles\Desktop\Arquivos\Projetos\ASP NET Core\Eventos.IO\src\Eventos.IO.Site\Areas\Identity\Pages\Account\AccessDenied.cshtml"
  
    ViewData["Title"] = "Acesso Negado";

#line default
#line hidden
            BeginContext(82, 40, true);
            WriteLiteral("\r\n<header>\r\n    <h1 class=\"text-danger\">");
            EndContext();
            BeginContext(123, 17, false);
#line 8 "C:\Users\Thalles\Desktop\Arquivos\Projetos\ASP NET Core\Eventos.IO\src\Eventos.IO.Site\Areas\Identity\Pages\Account\AccessDenied.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(140, 86, true);
            WriteLiteral("</h1>\r\n    <p class=\"text-danger\">Você não tem acesso à este recurso.</p>\r\n</header>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccessDeniedModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccessDeniedModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccessDeniedModel>)PageContext?.ViewData;
        public AccessDeniedModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
