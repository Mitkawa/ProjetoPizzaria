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
        public int PizzaId { get; private set; }
        public Sabor Sabor { get; set; }
        public int SaborId { get; private set; }


    }
}
