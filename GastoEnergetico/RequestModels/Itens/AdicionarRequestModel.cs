using GastoEnergetico.Models.Categorias;
using GastoEnergetico.Models.Itens;

namespace GastoEnergetico.RequestModels.Itens
{
    public class AdicionarRequestModel: IDadosBasicosItensModel
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