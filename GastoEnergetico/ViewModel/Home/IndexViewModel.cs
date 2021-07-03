using System.Collections.Generic;

namespace GastoEnergetico.ViewModel.Home
{
    public class IndexViewModel
    {
        public ICollection<CategoriaQueCosome> CategoriasQueMaisConsomem { get; set; }

        public IndexViewModel()
        {
            CategoriasQueMaisConsomem = new List<CategoriaQueCosome>();
        }
    }
}

public class CategoriaQueCosome
{
    public string Posicao { get; set; }
    public string NomeCategoria { get; set; }
    public string ConsumoMensalKwh { get; set; }
    public string ValorMensalKwh { get; set; }
}