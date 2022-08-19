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

        public IActionResult Atualizar(int id) 
        {
            var search = _context.Pizzas.Include(x=>x.PizzasSabores).ThenInclude(x=>x.Sabor).FirstOrDefault(x=> x.Id== id);

            if (search == null) 
                return View("NotFound");

            var response = new PostPizzaDTO()
            {
                Nome = search.Nome,
                FotoURL = search.FotoURL,
                Preco = search.Preco,
                TamanhoId = search.TamanhoId,
                SaborId = search.PizzasSabores.Select(x=>x.SaborId).ToList()
            };

            DadosDropdown();

            return View(response);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostPizzaDTO pizzaDTO)
        {
            var search = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            if(!ModelState.IsValid)
            {
                DadosDropdown();
                return View(search);
            }

            search.AtualizarDados
                (
                pizzaDTO.Nome=search.Nome,
                pizzaDTO.FotoURL=search.FotoURL,
                pizzaDTO.Preco=search.Preco,
                pizzaDTO.TamanhoId=search.TamanhoId
                );

            _context.Update(search);
            _context.SaveChanges();

            return  RedirectToAction(nameof(Detalhes),search);

        }

        public IActionResult Deletar(int id) 
        {
            var search = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            if (search == null)
                return View("NotFound");



            return View(search);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id) 
        {
            var result = _context.Pizzas.FirstOrDefault(x=>x.Id==id);

            _context.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id) 
        {
            var result = _context.Pizzas.Include(t => t.TamanhoId).Include(ps => ps.PizzasSabores).ThenInclude(s => s.Sabor).FirstOrDefault(p=>p.Id==id);

            return View(result);
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
