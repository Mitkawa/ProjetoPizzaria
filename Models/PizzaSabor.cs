using System.ComponentModel.DataAnnotations;

namespace Projeto_Pizzaria.Models
{
    public class PizzaSabor
    {
        public PizzaSabor(int saborId, int pizzaId)
        {
            SaborId = saborId;
            PizzaId = pizzaId;
        }
        public Pizza Pizza { get; set; }
        [Key]
        public int PizzaId { get; private set; }
        public Sabor Sabor { get; set; }
        [Key]
        public int SaborId { get; private set; }


    }
}
