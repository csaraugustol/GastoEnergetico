using GastoEnergetico.Models.Categorias;
using GastoEnergetico.Models.Itens;
using GastoEnergetico.ViewModel.Itens;
using Microsoft.AspNetCore.Mvc;

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

            
            viewModel.ValidarEFiltrar();
            
            return View();
        }
    }
}