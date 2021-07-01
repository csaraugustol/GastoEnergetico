using System.Collections.Generic;
using System.Linq;
using GastoEnergetico.Data;
using Microsoft.EntityFrameworkCore;

namespace GastoEnergetico.Models.Itens
{
    public class ItensService : IDadosBasicosItensModel
    {
        public string Id { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DataFabricacao { get; set; }
        public string ConsumoWatts { get; set; }
        public string HorasUsoDiario { get; set; }
        
        private readonly DataBaseContext _dataBaseContext;

        public ItensService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        
        public ICollection<ItensEntity> BuscarTodos()
        {
            return _dataBaseContext.Itens
                .Include(i => i.Categoria)
                .ToList();
        }
        
        public ICollection<ItensEntity> ObterTodos()
        {
            return _dataBaseContext.Itens.Include(c => c.Categoria).ToList();
        }
    }

    public interface IDadosBasicosItensModel
    {
        public string Id { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DataFabricacao { get; set; }
        public string ConsumoWatts { get; set; }
        public string HorasUsoDiario { get; set; }
    }
}


