#pragma checksum "T:\marci_cuccai\beadando\KepRendszerezo\KepRendszerezo\Views\FolderList\AddNewFolder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a70ba63c18c144c7a55887c91ac8fb4fa79fa10e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FolderList_AddNewFolder), @"mvc.1.0.view", @"/Views/FolderList/AddNewFolder.cshtml")]
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
#line 1 "T:\marci_cuccai\beadando\KepRendszerezo\KepRendszerezo\Views\_ViewImports.cshtml"
using KepRendszerezo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "T:\marci_cuccai\beadando\KepRendszerezo\KepRendszerezo\Views\_ViewImports.cshtml"
using KepRendszerezo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a70ba63c18c144c7a55887c91ac8fb4fa79fa10e", @"/Views/FolderList/AddNewFolder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a708a95bc3c8a90fd50f319c2e5fa7ee709bcfa6", @"/Views/_ViewImports.cshtml")]
    public class Views_FolderList_AddNewFolder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("Sikeresen hozzáadta az új mappát!\r\n<br />\r\n");
#nullable restore
#line 3 "T:\marci_cuccai\beadando\KepRendszerezo\KepRendszerezo\Views\FolderList\AddNewFolder.cshtml"
Write(Html.ActionLink("Vissza a főoldalra", "index", "home"));

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
