using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GastoEnergetico.Data;
using Microsoft.EntityFrameworkCore;

namespace GastoEnergetico.Models.Categorias
{
    public class CategoriasService
    {
        private readonly DataBaseContext _dataBaseContext;

        public CategoriasService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }


        public ICollection<CategoriasEntity> BuscarTodos()
        {
            return _dataBaseContext.Categorias.ToList();
        }
    }
}