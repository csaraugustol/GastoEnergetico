using System.Collections.Generic;
using System.Diagnostics;

namespace GastoEnergetico.ViewModel.Home
{
    public class IndexViewModel
    {
        public ICollection<CategoriaQueCosome> CategoriasQueMaisConsomem { get; set; }
        public ICollection<ItemQueConsome> ItensQueMaisConsomem { get; set; }
        public IndexViewModel()
        {
            CategoriasQueMaisConsomem = new List<CategoriaQueCosome>();
            ItensQueMaisConsomem = new List<ItemQueConsome>();
        }
    }
}

public class ItemQueConsome
{
    public string Posicao { get; set; }
    public string NomeItem { get; set; }
    public string NomeCategoriaItem { get; set; }
    public string ConsumoMensalKwh { get; set; }
    public string ValorMensalKwh { get; set; }
}
public class CategoriaQueCosome
{
    public string Posicao { get; set; }
    public string NomeCategoria { get; set; }
    public string ConsumoMensalKwh { get; set; }
    public string ValorMensalKwh { get; set; }
}