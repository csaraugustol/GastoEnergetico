using System.Collections;
using System.Collections.Generic;

namespace GastoEnergetico.ViewModel.Categorias
{
    public class EditarViewModel
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string CategoriaPaiId { get; set; }
        
        public ICollection ValidarEFiltrar()
        {
            var listaErros = new List<string>();

            return listaErros;
        }
    }
}