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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();

            var categoriasQueMaisConsomem = _analisesService.CategoriasQueMaisConsomem();

            var posicao = 0;
            foreach (var consumoCategoria in categoriasQueMaisConsomem)
            {
                viewModel.CategoriasQueMaisConsomem.Add(new CategoriaQueCosome
                {
                    Posicao = (posicao+= 1).ToString(),
                    NomeCategoria = consumoCategoria.Categoria,
                    ConsumoMensalKwh = consumoCategoria.ConsumoMensalKwh.ToString("N"),
                    ValorMensalKwh = consumoCategoria.ValorMensalKwh.ToString("C"),
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