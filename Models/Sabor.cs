using Projeto_Pizzaria.Models.Interface;
using System;
using System.Collections.Generic;

namespace Projeto_Pizzaria.Models
{
    public class Sabor : IEntidade
    {
        public DateTime DataAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string FotoUrl { get; set; }
        public List<PizzaSabor> PizzasSabores { get; set; }
        
    }
}
