using System.Collections.Generic;
using System.Collections.ObjectModel;
using GastoEnergetico.Models.Categorias;

namespace GastoEnergetico.ViewModel.Itens
{
    public class IndexViewModel
    {
        public ICollection<Item> Items { get; set; }

        public IndexViewModel()
        {
            Items = new List<Item>();
        }
    }

    public class Item
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