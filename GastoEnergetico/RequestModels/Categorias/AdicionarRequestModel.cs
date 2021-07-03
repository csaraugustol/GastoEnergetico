using GastoEnergetico.Models.Categorias;

namespace GastoEnergetico.RequestModels.Categorias
{
    public class AdicionarRequestModel: IDadosBasicosCategoriaModel
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string CategoriaPaiId { get; set; }
        
        
    }
}