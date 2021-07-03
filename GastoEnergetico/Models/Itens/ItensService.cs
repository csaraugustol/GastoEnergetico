using System;
using System.Collections.Generic;
using System.Linq;
using GastoEnergetico.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace GastoEnergetico.Models.Itens
{
    public class ItensService : IDadosBasicosItensModel
    {

        public string Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DataFabricacao { get; set; }
        public string ConsumoWatts { get; set; }
        public string HorasUsoDiario { get; set; }
        
        private readonly DataBaseContext _dataBaseContext;

        public ItensService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        
        public ICollection<ItensEntity> BuscarTodos()
        {
            return _dataBaseContext.Itens
                .Include(i => i.Categoria)
                .ToList();
        }
        
        public ItensEntity ObterPorId(int id)
        {
            return _dataBaseContext.Itens.
                Find(id);
        }
        
        public ICollection<ItensEntity> ObterTodos()
        {
            return _dataBaseContext.Itens.Include(c => c.Categoria).ToList();
        }
        
        public ICollection<ItensEntity> ObterTodosPorCategoria(int id)
        {
            return _dataBaseContext.Itens.Include(c => c.Categoria).Where(c=>c.Id == id).ToList();
        }
        
        public ItensEntity Adicionar(IDadosBasicosItensModel dadosBasicos)
        {
            var novaEntidade = ValidarDadosBasicos(dadosBasicos);
            _dataBaseContext.Itens.Add(novaEntidade);
            _dataBaseContext.SaveChanges();

            return novaEntidade;
        }
        
        private ItensEntity ValidarDadosBasicos(
            IDadosBasicosItensModel dadosBasicosP,
            ItensEntity entidadeExistente = null
        )
        {
            var entidade = entidadeExistente ?? new ItensEntity();

           /* if (dadosBasicosP.Descricao == null  || dadosBasicosP.CategoriaPaiId == null)
            {
                throw new Exception("Campo obrigatório.");
            }*/

            try
            {
                var valor = dadosBasicosP.Nome;
                entidade.Nome = valor;
            }
            catch (Exception e)
            {
                throw new Exception("Verifique a informação digitada.");
            }
            
            try
            {
                var valor = dadosBasicosP.Descricao;
                entidade.Descricao = valor;
            }
            catch (Exception e)
            {
                throw new Exception("Verifique a informação digitada.");
            }
            
            try
            {
                var valor = DateTime.Parse(dadosBasicosP.DataFabricacao);
                entidade.DataFabricacao = valor;
            }
            catch (Exception e)
            {
                throw new Exception("Verifique a informação digitada.");
            }
            
            try
            {
                var valor = Decimal.Parse(dadosBasicosP.ConsumoWatts);
                entidade.ConsumoWatts = valor;
            }
            catch (Exception e)
            {
                throw new Exception("Verifique a informação digitada.");
            }
            
            try
            {
                var valor = IntegerType.FromString(dadosBasicosP.HorasUsoDiario);
                entidade.HorasUsoDiario = valor;
            }
            catch (Exception e)
            {
                throw new Exception("Verifique a informação digitada.");
            }
            
            
            try
            {
                
            }
            catch (Exception e)
            {
                throw new Exception("Verifique a informação digitada.");
            }
            
           
            
            return entidade;
        }
    }

    public interface IDadosBasicosItensModel
    {

        public string Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DataFabricacao { get; set; }
        public string ConsumoWatts { get; set; }
        public string HorasUsoDiario { get; set; }
    }
}


