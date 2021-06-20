using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GastoEnergetico.ViewModel.Categorias
{
    public class IndexViewModel
    {
        public ICollection<Categoria> Categorias { get; set; }

        public IndexViewModel()
        {
            Categorias = new List<Categoria>();
        }
    }


    public class Categoria
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string CategoriaPaiId { get; set; }
    }
}