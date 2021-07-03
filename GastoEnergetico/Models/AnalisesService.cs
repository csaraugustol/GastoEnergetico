using System.Collections.Generic;
using GastoEnergetico.Data;
using GastoEnergetico.Models.Categorias;
using GastoEnergetico.Models.Itens;
using GastoEnergetico.Models.Parametros;

namespace GastoEnergetico.Models
{
    public class AnalisesService
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly ParametrosService _parametrosService;
        private readonly CategoriasService _categoriasService;
        private readonly ItensService _itensService;
        
        
        public AnalisesService(DataBaseContext dataBaseContext, ParametrosService parametrosService, CategoriasService categoriasService, ItensService itensService)
        {
            _dataBaseContext = dataBaseContext;
            _parametrosService = parametrosService;
            _categoriasService = categoriasService;
            _itensService = itensService;
        }

        public ICollection<ConsumoCategoria> CategoriasQueMaisConsomem()
        {
        }
    }
}