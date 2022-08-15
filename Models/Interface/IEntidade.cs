using System;

namespace Projeto_Pizzaria.Models.Interface
{
    public interface IEntidade
    {
         DateTime DataAlteracao { get;}
         DateTime DataCadastro { get;}
         int Id { get;}
    }
}
