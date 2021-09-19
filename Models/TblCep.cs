using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class TblCep
    {
        public int IdCep { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Complemento { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public int Gia { get; set; }
        public int Ddd { get; set; }
        public int Siafi { get; set; }
    }
}
