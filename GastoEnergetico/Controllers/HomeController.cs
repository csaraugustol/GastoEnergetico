using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GastoEnergetico.Models;
using GastoEnergetico.ViewModel.Home;

namespace GastoEnergetico.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AnalisesService _analisesService;

        public HomeController(ILogger<HomeController> logger, AnalisesService analisesService)
        {
            _logger = logger;
            _analisesService = analisesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();

            var totalConsumos = _analisesService.totalConsumo();
            foreach (var consumoTotal in totalConsumos)
            {
                viewModel.totalConsumos.Add(new TotalConsumo
                {
                    FaixaDeConsumo = consumoTotal.FaixaDeConsumo,
                    ConsumoMensalWatts = consumoTotal.ConsumoMensalWatts.ToString("N"),
                    ValorMensalKwh = consumoTotal.ValorMensalKwh.ToString("C")
                });
            }
            var categoriasQueMaisConsomem = _analisesService.CategoriasQueMaisConsomem();
            var posicao = 0;
            foreach (var consumoCategoria in categoriasQueMaisConsomem)
            {
                viewModel.CategoriasQueMaisConsomem.Add(new CategoriaQueCosome
                {
                    Posicao = (posicao+= 1).ToString(),
                    NomeCategoria = consumoCategoria.Categoria,
                    ConsumoMensalKwh = consumoCategoria.ConsumoMensalKwh.ToString("N"),
                    ValorMensalKwh = consumoCategoria.ValorMensalKwh.ToString("C")
                });
            }

            var itensQueMaisConsomem = _analisesService.ItensQueMaisConsomem();
            var posicao1 = 0;
            foreach (var consumoItem in itensQueMaisConsomem)
            {
                viewModel.ItensQueMaisConsomem.Add(new ItemQueConsome
                {
                    Posicao = (posicao1 += 1).ToString(),
                    NomeItem = consumoItem.Item,
                    NomeCategoriaItem = consumoItem.Categoria,
                    ConsumoMensalKwh = consumoItem.ConsumoMensalKwh.ToString("N"),
                    ValorMensalKwh = consumoItem.ValorMensalKwh.ToString("C")
                });
            }
            
            
            
            return View(viewModel);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}