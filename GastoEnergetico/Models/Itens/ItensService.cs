using System.Collections.Generic;
using System.Linq;
using GastoEnergetico.Data;
using Microsoft.EntityFrameworkCore;

namespace GastoEnergetico.Models.Itens
{
    public class ItensService
    {
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
}


