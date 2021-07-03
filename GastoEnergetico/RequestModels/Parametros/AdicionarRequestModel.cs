using GastoEnergetico.Models.Parametros;

namespace GastoEnergetico.RequestModels.Parametros
{
    public class AdicionarRequestModel : IDadosBasicosParametrosModel
    {
        public string ValorKwh { get; set; }
        public string FaixaConsumoAlto { get; set; }
        public string FaixaConsumoMedio { get; set; }
        
    }
}