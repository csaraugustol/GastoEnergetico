using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GastoEnergetico.Data;
using GastoEnergetico.Models.Categorias;
using GastoEnergetico.Models.Itens;
using GastoEnergetico.Models.Parametros;
using Microsoft.VisualBasic;

namespace GastoEnergetico.Models
{
    public class AnalisesService
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly ParametrosService _parametrosService;
        private readonly CategoriasService _categoriasService;
        private readonly ItensService _itensService;
        
        
        public AnalisesService(DataBaseContext dataBaseContext, ParametrosService parametrosService, CategoriasService categoriasService, ItensService itensService)
        {
            _dataBaseContext = dataBaseContext;
            _parametrosService = parametrosService;
            _categoriasService = categoriasService;
            _itensService = itensService;
        }

        public ICollection<ConsumoItem> ItensQueMaisConsomem()
        {
            var parametrosAtivos = _parametrosService.ObterParametroAtivo();
            var todosItens = _itensService.BuscarTodos();
            var listaDeConsumos = new Collection<ConsumoItem>();
            decimal consumoMensalItens = 0;
            foreach (var itensEntity in todosItens)
            {
                consumoMensalItens += itensEntity.CalcularGastoEnergeticoMensalKwh();
            }

            foreach (var itensEntity in todosItens )
            {
                listaDeConsumos.Add(new ConsumoItem()
                {
                    Item = itensEntity.Nome,
                    Categoria = itensEntity.Categoria.Descricao,
                    ConsumoMensalKwh = consumoMensalItens,
                    ValorMensalKwh = consumoMensalItens * parametrosAtivos.ValorKwh
                });
            }
            return  listaDeConsumos.OrderByDescending(c => c.ConsumoMensalKwh).Take(5).ToList();

        }
        public ICollection<ConsumoTotal> totalConsumo()
        {
            var parametrosAtivos = _parametrosService.ObterParametroAtivo();
            var todosItens = _itensService.BuscarTodos();
            var listaDeConsumos = new Collection<ConsumoTotal>();
            decimal consumoMensalItens = 0;
            foreach (var itensEntity in todosItens)
            {
                consumoMensalItens += itensEntity.CalcularGastoEnergeticoMensalKwh();
            }

            foreach (var itensEntity in todosItens )
            {
                var ct = new ConsumoTotal();
                var maior = parametrosAtivos.FaixaConsumoAlto;
                var medio = parametrosAtivos.FaixaConsumoMedio;
                var faixa = "";
                if (consumoMensalItens > maior)
                {
                    faixa = "ALTO CONSUMO";
                }else if (consumoMensalItens < maior && consumoMensalItens >= medio)
                {
                    faixa = "MEDIO CONSUMO";
                }
                else
                {
                    faixa = "BAIXO CONSUMO";
                }

                ct.FaixaDeConsumo = faixa;
                ct.ConsumoMensalWatts = consumoMensalItens;
                ct.ValorMensalKwh = consumoMensalItens * parametrosAtivos.ValorKwh;
                listaDeConsumos.Add(ct);
            }
            return listaDeConsumos.OrderByDescending(c => c.ConsumoMensalWatts).Take(1).ToList();

        }
        public ICollection<ConsumoCategoria> CategoriasQueMaisConsomem()
        {
            var parametrosAtivos = _parametrosService.ObterParametroAtivo();
            var todasCategorias = _categoriasService.BuscarTodos();
            var listaDeConsumos = new Collection<ConsumoCategoria>();
            foreach (var categoriaEntity in todasCategorias)
            {
                var itensDaCategoria = _itensService.ObterTodosPorCategoria(categoriaEntity.Id);
                decimal consumoMensalItens = 0;
                foreach (var itensEntity in itensDaCategoria)
                {
                    consumoMensalItens += itensEntity.CalcularGastoEnergeticoMensalKwh();
                }
                listaDeConsumos.Add(new ConsumoCategoria()
                {
                    Categoria = categoriaEntity.Descricao,
                    ConsumoMensalKwh = consumoMensalItens,
                    ValorMensalKwh = consumoMensalItens * parametrosAtivos.ValorKwh
                });
            }

            
            
            return listaDeConsumos.OrderByDescending(c => c.ConsumoMensalKwh).Take(3).ToList();
        }
    }

    public class ConsumoTotal
    {
        public string FaixaDeConsumo { get; set; }
        public decimal ConsumoMensalWatts { get; set; }
        public decimal ValorMensalKwh { get; set; }
    }
    public class ConsumoCategoria
    {
        public string Categoria { get; set; }
        public decimal ConsumoMensalKwh { get; set; }
        public decimal ValorMensalKwh { get; set; }
    }

    public class ConsumoItem
    {
        public string Item { get; set; }
        
        public string Categoria { get; set; }
        public decimal ConsumoMensalKwh { get; set; }
        public decimal ValorMensalKwh { get; set; }
        
    }
}