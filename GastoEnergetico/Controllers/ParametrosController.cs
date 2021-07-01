using System;
using GastoEnergetico.Models.Parametros;
using GastoEnergetico.RequestModels.Parametros;
using GastoEnergetico.ViewModel.Parametros;
using Microsoft.AspNetCore.Mvc;

namespace GastoEnergetico.Controllers
{
    public class ParametrosController : Controller
    {
        private readonly ParametrosService _parametrosService;

        public ParametrosController(ParametrosService parametrosService)
        {
            _parametrosService = parametrosService;
        }

        public IActionResult Index()
        {
            //View para exibição de dados para o usuário
            var viewModel = new IndexViewModel();
            
            //Busca todos os gastos
            var listaParametrosEntities = _parametrosService.BuscarTodos();
            
            //Processar a lista e passar para ViewModel
            foreach (ParametrosEntity parametrosEntity in listaParametrosEntities)
            {
                viewModel.Parametros.Add(new Parametro()
                {
                    Id = parametrosEntity.Id.ToString(),
                    FaixaConsumoAlto = parametrosEntity.FaixaConsumoAlto.ToString("N"),
                    FaixaConsumoMedio = parametrosEntity.FaixaConsumoMedio.ToString("N"),
                    ValorKwh = parametrosEntity.ValorKwh.ToString("C")
                });
            }
            
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            var viewModel = new AdicionarViewModel();

            
            viewModel.ValidarEFiltrar();
            
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Adicionar(AdicionarRequestModel requestModel)
        {
            try
            {
                _parametrosService.Adicionar(requestModel);
                TempData["FormMensSucess"] = "Parâmetros adiconados com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Adicionar");
            }
            
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            try
            {
                var entidadeEsc = _parametrosService.ObterPorId(id);

                var viewModel = new EditarViewModel()
                {
                    Id = entidadeEsc.Id.ToString(),
                    ValorKwh = entidadeEsc.ValorKwh.ToString("C"),
                    FaixaConsumoAlto = entidadeEsc.FaixaConsumoAlto.ToString("N"),
                    FaixaConsumoMedio = entidadeEsc.FaixaConsumoMedio.ToString("N")
                };
                
                return View(viewModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
        
        [HttpPost]
        public IActionResult Editar(int id, EditarRequestModel requestModel)
        {
            try
            {
                _parametrosService.Editar(id, requestModel);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Editar");
            }
        }
    }
    
    
}