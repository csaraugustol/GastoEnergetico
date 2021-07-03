using System.Collections;
using System.Collections.Generic;
using GastoEnergetico.Models.Categorias;
using GastoEnergetico.Models.Itens;
using GastoEnergetico.ViewModel.Categorias;

namespace GastoEnergetico.ViewModel.Itens
{
    public class AdicionarViewModel : IDadosBasicosItensModel
    {
        public string Id { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DataFabricacao { get; set; }
        public string ConsumoWatts { get; set; }
        public string HorasUsoDiario { get; set; }

        public AdicionarViewModel()
        {
            ListaCategorias = new List<Categoria>();
        }


        public ICollection ValidarEFiltrar()
        {
            var listaErros = new List<string>();

            return listaErros;
        }

        public ICollection<Categoria> ListaCategorias { get; set; }
        
        
    }

   
}