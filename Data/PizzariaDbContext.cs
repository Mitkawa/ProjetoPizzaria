using Microsoft.EntityFrameworkCore;
using Projeto_Pizzaria.Models;

namespace Projeto_Pizzaria.Data
{
    public class PizzariaDbContext : DbContext
    {
        public PizzariaDbContext(DbContextOptions<PizzariaDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaSabor>().HasKey(ps => new
            {
                ps.SaborId,
                ps.PizzaId
            });
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaSabor> PizzasSabores { get; set; }
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }

        
    }
}
