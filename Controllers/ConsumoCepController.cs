using ConsumoCepAPI.Application;
using ConsumoCepAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoCepAPI.Controllers
{
    [ApiController]
    [Route("api/ConsumoCep")]
    public class ConsumoCepController : ControllerBase
    {
        private IConsultaService _consultaService;
        public ConsumoCepController(IConsultaService consultaService) 
        {
            _consultaService = consultaService;
        }

        [HttpGet("{cep}")]
        public IActionResult Consultar(string cep) 
        {
            var retorno = _consultaService.ConsultarCep(cep);
            return Ok(retorno);
        }

        [HttpPost]
        public IActionResult Inserir(CepDTO cep)
        {
            _consultaService.InserirCep(cep);
            return Ok();
        }

    }
}
