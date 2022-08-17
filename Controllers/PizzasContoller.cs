using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Pizzaria.Data;
using Projeto_Pizzaria.Models.ViewsModels.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Pizzaria.Models;

namespace Projeto_Pizzaria.Controllers
{
    public class PizzasContoller : Controller
    {
        private PizzariaDbContext _context;

        public PizzasContoller(PizzariaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Pizzas);

        public IActionResult Criar() => View();



        public IActionResult Detalhes(int id)
        {
            var resultado = _context.Pizzas
                .Include(ps => ps.PizzasSabores)
                .ThenInclude(p => p.Pizza)
                .FirstOrDefault(pizza => pizza.Id == id);

            if (resultado == null)
                return View("NotFound");

            return View(resultado);
        }

        [HttpPost]
        public IActionResult Criar(PostPizzaDTO pizzadto)
        {
            if (!ModelState.IsValid)
            {
                DadosDropdown();
                return View();
            }

            Pizza pizza = new Pizza
                (
                    pizzadto.Nome,
                    pizzadto.FotoURL,
                    pizzadto.Preco,
                    pizzadto.TamanhoId
                ); 

            _context.Add(pizza);
            _context.SaveChanges();

            foreach (var saborid in pizzadto.SaborId)
            {
                var novosabor = new PizzaSabor(pizza.Id, saborid);
                _context.PizzasSabores.Add(novosabor);
                _context.SaveChanges();
            }

            return View();
        }
        public void DadosDropdown()
        {
            var resp = new PostPizzaDropdownDTO()
            {
                Sabores = _context.Sabores.OrderBy(x => x.Nome).ToList(),
                Tamanhos = _context.Tamanhos.OrderBy(x => x.Nome).ToList()
            };
        }
    }
}
