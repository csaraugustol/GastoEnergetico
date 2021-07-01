using System;
using GastoEnergetico.Models.Categorias;
using GastoEnergetico.RequestModels.Categorias;
using GastoEnergetico.ViewModel.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace GastoEnergetico.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly CategoriasService _categoriasService;

        public CategoriasController(CategoriasService categoriasService)
        {
            _categoriasService = categoriasService;
        }

        // GET
        public IActionResult Index()
        {
            //View para exibição de dados para o usuário
            var viewModel = new IndexViewModel();

            
            //Busca todos os gastos
            var listaCategoriasEntities = _categoriasService.BuscarTodos();
            
            //Processar a lista e passar para ViewModel
            foreach (CategoriasEntity categoriasEntity in listaCategoriasEntities)
            {
                viewModel.Categorias.Add(new Categoria()
                {
                    Id = categoriasEntity.Id.ToString(),
                    Descricao = categoriasEntity.Descricao,
                    CategoriaPaiId = categoriasEntity.CategoriaPaiId.ToString()
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
                _categoriasService.Adicionar(requestModel);
                TempData["FormMensSucess"] = "Categorias adiconadas com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Adicionar");
            }
            
        }


        
    }
}