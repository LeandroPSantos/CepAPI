using ConsumoCepAPI.Application;
using ConsumoCepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoCepAPI.Services
{
    public class ConsultaCep : IConsultaService
    {
        private DbContexto _cx;
        public ConsultaCep(DbContexto cx) 
        {
            _cx = cx;
        }
        public TblCep ConsultarCep(string cep)
        {
            try
            {
                var retorno = _cx.TblCeps.Where(w => w.Cep == (cep.Length == 9 ? cep.Remove(5, 1) : cep)).FirstOrDefault();
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InserirCep(CepDTO cep)
        {
            try
            {
                var consulta = _cx.TblCeps.Where(w => w.Cep == (cep.Cep.Length == 9 ? cep.Cep.Remove(5, 1) : cep.Cep)).FirstOrDefault();

                if(consulta != null) //consulta primeiro para verificar se existe algum registro ja com esse CEP
                {
                    consulta.IdCep = consulta.IdCep;

                    consulta.Cep = cep.Cep;
                    consulta.Bairro = cep.Bairro;
                    consulta.Complemento = cep.Complemento;
                    consulta.Ddd = cep.Ddd;
                    consulta.Gia = cep.Gia;
                    consulta.Ibge = cep.Ibge;
                    consulta.Localidade = cep.Localidade;
                    consulta.Logradouro = cep.Logradouro;
                    consulta.Siafi = cep.Siafi;
                    consulta.Uf = cep.Uf;

                    _cx.Update(consulta);
                    _cx.SaveChanges();
                }
                else //se não possuir inclui um novo
                {

                    TblCep tabelaCep = new TblCep();

                    tabelaCep.Cep = cep.Cep.Remove(5, 1);
                    tabelaCep.Bairro = cep.Bairro;
                    tabelaCep.Complemento = cep.Complemento;
                    tabelaCep.Ddd = cep.Ddd;
                    tabelaCep.Gia = cep.Gia;
                    tabelaCep.Ibge = cep.Ibge;
                    tabelaCep.Localidade = cep.Localidade;
                    tabelaCep.Logradouro = cep.Logradouro;
                    tabelaCep.Siafi = cep.Siafi;
                    tabelaCep.Uf = cep.Uf;

                    _cx.Add(tabelaCep);
                    _cx.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
