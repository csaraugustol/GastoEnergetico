using System.Collections;
using System.Collections.Generic;
using GastoEnergetico.Models.Categorias;

namespace GastoEnergetico.ViewModel.Categorias
{
    public class AdicionarViewModel : IDadosBasicosCategoriaModel
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