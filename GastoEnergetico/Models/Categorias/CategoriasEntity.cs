namespace GastoEnergetico.Models.Categorias
{
    public class CategoriasEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int CategoriaPaiId { get; set; }

        public CategoriasEntity()
        {
        }

        public CategoriasEntity(int id, string descricao, int categoriaPaiId)
        {
            Id = id;
            Descricao = descricao;
            CategoriaPaiId = categoriaPaiId;
        }
    }
}