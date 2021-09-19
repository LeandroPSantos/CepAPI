using ConsumoCepAPI.Application;
using ConsumoCepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoCepAPI.Services
{
    public interface IConsultaService
    {
        void InserirCep(CepDTO cep);

        TblCep ConsultarCep(string cep);
    }
}
