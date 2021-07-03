using System;
using GastoEnergetico.Models.Categorias;
using GastoEnergetico.Models.Itens;
using GastoEnergetico.RequestModels.Itens;
using GastoEnergetico.ViewModel.Categorias;
using GastoEnergetico.ViewModel.Itens;
using Microsoft.AspNetCore.Mvc;
using AdicionarViewModel = GastoEnergetico.ViewModel.Itens.AdicionarViewModel;
using EditarViewModel = GastoEnergetico.ViewModel.Itens.EditarViewModel;
using IndexViewModel = GastoEnergetico.ViewModel.Itens.IndexViewModel;

namespace GastoEnergetico.Controllers
{
    public class ItensController : Controller
    {
        private readonly ItensService _itensService;
        private readonly CategoriasService _categoriasService;


        public ItensController(ItensService itensService, CategoriasService categoriasService)
        {
            _itensService = itensService;
            _categoriasService = categoriasService;
        }

        public IActionResult Index()
        {
            
            var viewModel = new IndexViewModel();

            //Busca todos os gastos
            var listaItensEntities = _itensService.BuscarTodos();
            
            //Processar a lista e passar para ViewModel
            foreach (ItensEntity itensEntity in listaItensEntities)
            {
                viewModel.Items.Add(new Item()
                {
                    Id = itensEntity.Id.ToString(),
                    Categoria =  itensEntity.Categoria.Id.ToString(),
                    Nome = itensEntity.Nome,
                    Descricao = itensEntity.Descricao,
                    DataFabricacao = itensEntity.DataFabricacao.ToShortDateString(),
                    ConsumoWatts = itensEntity.ConsumoWatts.ToString("N"),
                    HorasUsoDiario = itensEntity.HorasUsoDiario.ToString()
                    
                });
                
            }
            
            return View(viewModel);
        }
        
        [HttpGet]
        public IActionResult Adicionar()
        {
            var viewModel = new AdicionarViewModel();

            var listaCategorias = _categoriasService.BuscarTodos();

            foreach (var categoria in listaCategorias)
            {
                viewModel.ListaCategorias.Add(new Categoria
                {
                    Id = categoria.Id.ToString(),
                    Descricao = categoria.Descricao,
                    CategoriaPaiId = categoria.CategoriaPaiId.ToString()
                });
            }
            
         //   viewModel.ValidarEFiltrar();
            
            return View();
        }
        
        
        [HttpPost]
        public RedirectToActionResult Adicionar(AdicionarRequestModel requestModel)
        {
            try
            {
                _itensService.Adicionar(requestModel);
                TempData["FormMensSucess"] = "Categorias adiconadas com sucesso.";
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
                var itensEntity = _itensService.ObterPorId(id);

                var viewModel = new EditarViewModel
                {
                    Id = itensEntity.Id.ToString(),
                    Categoria =  itensEntity.Categoria.Id.ToString(),
                    Nome = itensEntity.Nome,
                    Descricao = itensEntity.Descricao,
                    DataFabricacao = itensEntity.DataFabricacao.ToShortDateString(),
                    ConsumoWatts = itensEntity.ConsumoWatts.ToString("N"),
                    HorasUsoDiario = itensEntity.HorasUsoDiario.ToString()
                };

                return View(viewModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
        
        
        
        
    }
}