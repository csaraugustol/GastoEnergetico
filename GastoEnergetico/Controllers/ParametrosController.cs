using GastoEnergetico.Models.Parametros;
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
                    ValorKwh = parametrosEntity.ValorKwh.ToString("N")
                });
            }
            
            return View(viewModel);
        }
    }
}