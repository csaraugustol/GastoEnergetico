using System.Collections.Generic;
using System.Linq;
using GastoEnergetico.Data;

namespace GastoEnergetico.Models.Parametros
{
    public class ParametrosService
    {
        private readonly DataBaseContext _dataBaseContext;

        public ParametrosService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        
        public ICollection<ParametrosEntity> BuscarTodos()
        {
            return _dataBaseContext.Parametros.ToList();
        }
    }
}