using Projeto_Pizzaria.Models.Interface;
using System;
using System.Collections.Generic;

namespace Projeto_Pizzaria.Models
{
    public class Sabor : IEntidade
    {
        public Sabor(int id, string nome, string fotoUrl)
        {
            Id = id;
            Nome = nome;
            FotoUrl = fotoUrl;
            DataCadastro = DateTime.Now;
            DataAlteracao= DataCadastro;
        }

        public DateTime DataAlteracao { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string FotoUrl { get; private set; }
        public List<PizzaSabor> PizzasSabores { get; set; }

        public void AtualizarDados(string nome, string fotourl) 
        {
            Nome= nome;
            FotoUrl= fotourl;

            DataAlteracao = DateTime.Now;
        }
        
    }
}
