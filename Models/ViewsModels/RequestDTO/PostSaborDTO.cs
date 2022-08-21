using System.ComponentModel.DataAnnotations;

namespace Projeto_Pizzaria.Models.ViewsModels.RequestDTO
{
    public class PostSaborDTO
    {
        [Required(ErrorMessage="Nome do sabor é obrigatório")]
        [StringLength(20, MinimumLength =3, ErrorMessage="Nome do sabor pode ter no máximo 20 caracteres e no minimo 3")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Imagem obrigatória")]
        public string FotoURL { get; set; }
    }
}
