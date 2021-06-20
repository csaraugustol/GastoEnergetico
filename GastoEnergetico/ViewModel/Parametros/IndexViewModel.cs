using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GastoEnergetico.ViewModel.Parametros
{
    public class IndexViewModel
    {
        public ICollection<Parametro> Parametros { get; set; }

        public IndexViewModel()
        {
            Parametros = new List<Parametro>();
            
        }
    }

    public class Parametro
    {
        public string Id { get; set; }
        public string ValorKwh { get; set; }
        public string FaixaConsumoAlto { get; set; }
        public string FaixaConsumoMedio { get; set; }
        
        
    }
}