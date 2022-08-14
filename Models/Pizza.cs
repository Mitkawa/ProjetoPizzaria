using Projeto_Pizzaria.Models.Interface;
using System;
using System.Collections.Generic;

namespace Projeto_Pizzaria.Models
{
    public class Pizza : IEntidade
    {

        public DateTime DataAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string FotoURL { get; set; }
        public Decimal Preco { get; set; }

        #region relacionamentos 

        public List<PizzaSabor> PizzasSabores { get; set; }
        public int TamanhoId { get; set; }
        public Tamanho Tamanho { get; set; }

        #endregion

    }
}
