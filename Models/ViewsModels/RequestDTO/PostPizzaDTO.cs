using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Pizzaria.Models.ViewsModels.RequestDTO
{
    public class PostPizzaDTO
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome da pizza é obrigatório!")]
        public string Nome { get;  set; }
        [Display(Name = "Foto")]
        [Required(ErrorMessage = "A foto é obrigatória !")]
        public string FotoURL { get;  set; }
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O preço é obrigatório!")]
        public decimal Preco { get;  set; }

        public int TamanhoId { get; set; }

        public List<int> SaborId { get; set; }
        
    }
}
