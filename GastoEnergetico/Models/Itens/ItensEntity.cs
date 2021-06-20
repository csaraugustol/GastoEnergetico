using System;
using GastoEnergetico.Models.Categorias;

namespace GastoEnergetico.Models.Itens
{
    public class ItensEntity
    {
        public int Id { get; set; }
        public CategoriasEntity Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public decimal ConsumoWatts { get; set; }
        public int HorasUsoDiario { get; set; }

        public ItensEntity()
        {
        }

        public ItensEntity(int id, CategoriasEntity categoria, string nome, string descricao, DateTime dataFabricacao, decimal consumoWatts, int horasUsoDiario)
        {
            Id = id;
            Categoria = categoria;
            Nome = nome;
            Descricao = descricao;
            DataFabricacao = dataFabricacao;
            ConsumoWatts = consumoWatts;
            HorasUsoDiario = horasUsoDiario;
        }
    }
}