#pragma checksum "C:\Users\Pedro\Desktop\index_c#\webapps\gastos\GastoEnergetico\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "976b85902336076d63a04a0e1ab85fe350725bb4"
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
#line 1 "C:\Users\Pedro\Desktop\index_c#\webapps\gastos\GastoEnergetico\Views\_ViewImports.cshtml"
using GastoEnergetico;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Pedro\Desktop\index_c#\webapps\gastos\GastoEnergetico\Views\_ViewImports.cshtml"
using GastoEnergetico.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"976b85902336076d63a04a0e1ab85fe350725bb4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cde47198d0312cec28c18c60341ee7adb9588c30", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GastoEnergetico.ViewModel.Home.IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Pedro\Desktop\index_c#\webapps\gastos\GastoEnergetico\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Mapa de Gastos Energéticos</h1>
    <h3>Controle os seus gastos enérgeticos e diminua o valor da conta de luz.</h3>
</div>
<div class=""d-flex justify-content-center mb-5"">
    <div class=""card"" style=""width: 25rem;"">
      
        <div class=""card-body"">
            <h5 class=""card-title"">Total de consumo de energia..</h5>
            <p class=""card-text"">
            
                <table class=""table table-hover table-dark table-striped"">
                    <thead>
                    <tr>
                        <th scope=""col"">Total gasto (Watts)</th>
                        <th scope=""col"">Valor Mensal</th>
                        <th scope=""col"">Faixa de consumo</th>
                    </tr>
                    </thead>
                    <tbody>
                    
                    </tbody>
                </table>
            </p>
        </div>
    </div>
</div>
<div class=""d-flex justify-content-center"">
<div");
            WriteLiteral(@" class=""card mr-5"" style=""width: 25rem;"">
  
    <div class=""card-body"">
        <h5 class=""card-title"">Categorias que mais consomem..</h5>
        <p class=""card-text"">
        
            <table class=""table table-hover table-light"">
                <thead>
                <tr>
                    <th scope=""col"">Posição</th>
                    <th scope=""col"">Categoria</th>
                    <th scope=""col"">Consumo Mensal (Kwh)</th>
                    <th scope=""col"">Valor Mensal</th>
                </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 50 "C:\Users\Pedro\Desktop\index_c#\webapps\gastos\GastoEnergetico\Views\Home\Index.cshtml"
                 foreach (var consumoCategoria in @Model.CategoriasQueMaisConsomem)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <th scope=\"col\">");
#nullable restore
#line 53 "C:\Users\Pedro\Desktop\index_c#\webapps\gastos\GastoEnergetico\Views\Home\Index.cshtml"
                                   Write(consumoCategoria.Posicao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\">");
#nullable restore
#line 54 "C:\Users\Pedro\Desktop\index_c#\webapps\gastos\GastoEnergetico\Views\Home\Index.cshtml"
                                   Write(consumoCategoria.NomeCategoria);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\">");
#nullable restore
#line 55 "C:\Users\Pedro\Desktop\index_c#\webapps\gastos\GastoEnergetico\Views\Home\Index.cshtml"
                                   Write(consumoCategoria.ConsumoMensalKwh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\">");
#nullable restore
#line 56 "C:\Users\Pedro\Desktop\index_c#\webapps\gastos\GastoEnergetico\Views\Home\Index.cshtml"
                                   Write(consumoCategoria.ValorMensalKwh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    </tr>\r\n");
#nullable restore
#line 58 "C:\Users\Pedro\Desktop\index_c#\webapps\gastos\GastoEnergetico\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </p>
    </div>
</div>

<div class=""card"" style=""width: 25rem;"">
  
    <div class=""card-body"">
        <h5 class=""card-title"">Itens que mais consomem..</h5>
        <p class=""card-text"">
        
            <table class=""table table-hover table-light"">
                <thead>
                <tr>
                    <th scope=""col"">Posição</th>
                    <th scope=""col"">Item</th>
                    <th scope=""col"">Consumo Mensal (Kwh)</th>
                    <th scope=""col"">Valor Mensal</th>
                </tr>
                </thead>
                <tbody>
                
                </tbody>
            </table>
        </p>
    </div>
</div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GastoEnergetico.ViewModel.Home.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
