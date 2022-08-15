using Projeto_Pizzaria.Models.Interface;
using System;
using System.Collections.Generic;

namespace Projeto_Pizzaria.Models
{
    public class Tamanho : IEntidade
    {
        public Tamanho(string nome)
        {
            Nome = nome;
            DataCadastro=DateTime.Now;
            DataAlteracao = DataCadastro;
        }

        public DateTime DataAlteracao { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public List<Pizza> Pizzas { get; set; }

        public void AtualizarDados(string nome) 
        {
            Nome=nome;
            DataAlteracao=DateTime.Now;
        }
    }
}
