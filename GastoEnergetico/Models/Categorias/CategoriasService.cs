using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GastoEnergetico.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace GastoEnergetico.Models.Categorias
{
    public class CategoriasService : IDadosBasicosCategoriaModel
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string CategoriaPaiId { get; set; }
        
        private readonly DataBaseContext _dataBaseContext;

        public CategoriasService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }


        public ICollection<CategoriasEntity> BuscarTodos()
        {
            return _dataBaseContext.Categorias.ToList();
        }
        
        public CategoriasEntity ObterPorId(int id)
        {
            return _dataBaseContext.Categorias.
                Find(id);
        }
        
        public CategoriasEntity Adicionar(IDadosBasicosCategoriaModel dadosBasicos)
        {
            var novaEntidade = ValidarDadosBasicos(dadosBasicos);
            _dataBaseContext.Categorias.Add(novaEntidade);
            _dataBaseContext.SaveChanges();

            return novaEntidade;
        }

        public CategoriasEntity Remover(int id)
        {
            var categoriaEntity = ObterPorId(id);
            _dataBaseContext.Categorias.Remove(categoriaEntity);
            _dataBaseContext.SaveChanges();
            return categoriaEntity;
        }
        public CategoriasEntity Editar(
            int id, 
            IDadosBasicosCategoriaModel dadosBasicos
        )
        {
            var entidadeAEditar = ObterPorId(id);

            entidadeAEditar = ValidarDadosBasicos(dadosBasicos, entidadeAEditar);
            _dataBaseContext.SaveChanges();

            return entidadeAEditar;
        }
        
        private CategoriasEntity ValidarDadosBasicos(
            IDadosBasicosCategoriaModel dadosBasicosP,
            CategoriasEntity entidadeExistente = null
        )
        {
            var entidade = entidadeExistente ?? new CategoriasEntity();

            if (dadosBasicosP.Descricao == null  || dadosBasicosP.CategoriaPaiId == null)
            {
                throw new Exception("Campo obrigatório.");
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
                var valor = IntegerType.FromString(dadosBasicosP.CategoriaPaiId);
                entidade.CategoriaPaiId = valor;
            }
            catch (Exception e)
            {
                throw new Exception("Informe um valor númerico.");
            }

            
            return entidade;
        }
    }


    public interface IDadosBasicosCategoriaModel
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string CategoriaPaiId { get; set; }
    }
}