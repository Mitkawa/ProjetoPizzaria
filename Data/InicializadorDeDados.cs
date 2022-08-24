//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;
//using Projeto_Pizzaria.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Projeto_Pizzaria.Data
//{
//    public class InicializadorDeDados
//    {
//        public static void Inicializar(IApplicationBuilder builder)
//        {
//            using (var serviceScope = builder.ApplicationServices.CreateScope())
//            {
//                var context = serviceScope.ServiceProvider.GetService<PizzariaDbContext>();

//                context.Database.EnsureCreated();

//                if (!context.Pizzas.Any())
//                {
//                    context.Pizzas.AddRange(new List<Pizza>()
//                    {
//                        new Pizza("Calabresa", "https://www.google.com/imgres?imgurl=https%3A%2F%2Ft2.rg.ltmcdn.com%2Fpt%2Fposts%2F9%2F8%2F3%2Fpizza_calabresa_e_mussarela_4389_600.jpg&imgrefurl=https%3A%2F%2Fwww.tudoreceitas.com%2Freceita-de-pizza-calabresa-e-mussarela-4389.html&tbnid=YHBQTM0ekextzM&vet=12ahUKEwjFofSqvsz5AhXyEbkGHdPnDU8QMygAegUIARDuAQ..i&docid=45H5BZcAyeRFcM&w=600&h=388&q=pizza%20calabresa&ved=2ahUKEwjFofSqvsz5AhXyEbkGHdPnDU8QMygAegUIARDuAQ", 40, 1)
//                    });
//                }

//                if (!context.Sabores.Any())
//                {
//                    context.Sabores.AddRange(new List<Sabor>()
//                    {
//                        new Sabor("Calabresa", "https://anamariabraga.globo.com/receita/pizza-de-calabresa-e-bacon-2/")
//                    });
//                }

//                if (!context.Tamanhos.Any())
//                {
//                    context.Tamanhos.AddRange(new List<Tamanho>()
//                    {
//                        new Tamanho("Grande"),
//                        new Tamanho("Média"),
//                        new Tamanho("Pequeno")

//                    });

//                    {

//                    }
//                }
//            }
//        }
//    }
//}
