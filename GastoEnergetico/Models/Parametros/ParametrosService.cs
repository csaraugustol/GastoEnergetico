using System;
using System.Collections.Generic;
using System.Linq;
using GastoEnergetico.Data;

namespace GastoEnergetico.Models.Parametros
{
    public class ParametrosService : IDadosBasicosParametrosModel
    {
    public string ValorKwh { get; set; }
        public string FaixaConsumoAlto { get; set; }
        public string FaixaConsumoMedio { get; set; }
        
        
        private readonly DataBaseContext _dataBaseContext;

        public ParametrosService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        
        public ICollection<ParametrosEntity> BuscarTodos()
        {
            return _dataBaseContext.Parametros.ToList();
        }

        public ParametrosEntity ObterParametroAtivo()
        {
            return _dataBaseContext.Parametros.First();
        }
        public ParametrosEntity ObterPorId(int id)
        {
            return _dataBaseContext.Parametros.
                Find(id);
        }

        public ParametrosEntity Adicionar(IDadosBasicosParametrosModel dadosBasicos)
        {
            var novaEntidade = ValidarDadosBasicos(dadosBasicos);
            _dataBaseContext.Parametros.Add(novaEntidade);
            _dataBaseContext.SaveChanges();

            return novaEntidade;
        }
        
        public ParametrosEntity Editar(
            int id, 
            IDadosBasicosParametrosModel dadosBasicos
            )
        {
            var entidadeAEditar = ObterPorId(id);

            entidadeAEditar = ValidarDadosBasicos(dadosBasicos, entidadeAEditar);
            _dataBaseContext.SaveChanges();

            return entidadeAEditar;
        }
        
        private ParametrosEntity ValidarDadosBasicos(
            IDadosBasicosParametrosModel dadosBasicosP,
            ParametrosEntity entidadeExistente = null
            )
        {
            var entidade = entidadeExistente ?? new ParametrosEntity();

            if (dadosBasicosP.ValorKwh == null || dadosBasicosP.FaixaConsumoAlto == null 
            || dadosBasicosP.FaixaConsumoMedio == null)
            {
                throw new Exception("Campo obrigatório.");
            }

            try
            {
                var valor = Decimal.Parse(dadosBasicosP.ValorKwh);
                entidade.ValorKwh = valor;
            }
            catch (Exception e)
            {
                throw new Exception("O valor digitado não é um formato válido.");
            }

            try
            {
                var fca = Decimal.Parse(dadosBasicosP.FaixaConsumoAlto);
                entidade.FaixaConsumoAlto = fca;
            }
            catch (Exception e)
            {
                throw new Exception("O valor digitado não é um formato válido.");
            }
            
            try
            {
                var fcm = Decimal.Parse(dadosBasicosP.FaixaConsumoMedio);
                entidade.FaixaConsumoMedio = fcm;
            }
            catch (Exception e)
            {
                throw new Exception("O valor digitado não é um formato válido.");
            }

            return entidade;
        }
    }


    public interface IDadosBasicosParametrosModel
    {

        public string ValorKwh { get; set; }
        public string FaixaConsumoAlto { get; set; }
        public string FaixaConsumoMedio { get; set; }
        
    }
}