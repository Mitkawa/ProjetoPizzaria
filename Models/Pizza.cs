using Projeto_Pizzaria.Models.Interface;
using System;
using System.Collections.Generic;

namespace Projeto_Pizzaria.Models
{
    public class Pizza : IEntidade
    {
        public Pizza(string nome, string fotoURL, decimal preco, int tamanhoid)
        {
            Nome = nome;
            FotoURL = fotoURL;
            Preco = preco;
            TamanhoId = tamanhoid;
            
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
        }

        public DateTime DataAlteracao { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public int Id { get;  private set; }
        public string Nome { get; private set; }
        public string FotoURL { get; private set; }
        public Decimal Preco { get; private set; }

        #region relacionamentos 

        public List<PizzaSabor> PizzasSabores { get; set; }
        public int TamanhoId { get; set; }
        public Tamanho Tamanho { get; set; }

        #endregion

        public void AtualizarDados(string nome, string fotourl, decimal preco, int tamanhoid) 
        {
            Nome = nome;
            FotoURL = fotourl;
            Preco = preco;
            TamanhoId = tamanhoid;

            DataAlteracao = DateTime.Now;
        }

    }
}
