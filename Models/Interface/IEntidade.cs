using System;

namespace Projeto_Pizzaria.Models.Interface
{
    public interface IEntidade
    {
         DateTime DataAlteracao { get; set; }
         DateTime DataCadastro { get; set; }
         int Id { get; set; }
    }
}
