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
    public class SaboresController : Controller
    {
        private PizzariaDbContext _context;

        public SaboresController(PizzariaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()=>View(_context.Sabores);

        public IActionResult Detalhes(int id) 
        {
            var result = _context.Sabores.Include(ps => ps.PizzasSabores).ThenInclude(p => p.Pizza).FirstOrDefault(sabor => sabor.Id == id);
            
            if (result == null) 
            {
                return View("NotFound");
            }
            return View(result);
        }
        public IActionResult Criar()=> View("Index");

        [HttpPost]
        public IActionResult Criar(PostSaborDTO saborDTO) 
        {
            if (!ModelState.IsValid)
                return View(saborDTO);

            Sabor sabor = new Sabor(saborDTO.Nome, saborDTO.FotoURL);
            _context.Sabores.Add(sabor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));  
        }

        public IActionResult Atualizar(int? id)
        {
            var result =_context.Sabores.FirstOrDefault(s => s.Id == id);

            if(result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]

        public IActionResult Atualizar(int id, PostSaborDTO saborDTO)
        {
            var sabor = _context.Sabores.FirstOrDefault(s => s.Id == id);

            if(!ModelState.IsValid)
            {
                return View(sabor);
            }

            sabor.AtualizarDados(saborDTO.Nome, saborDTO.FotoURL);
            _context.Update(sabor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            var result = _context.Sabores.FirstOrDefault(s => s.Id == id);

            if (result == null) return View();

            return View(result);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Sabores.FirstOrDefault(s => s.Id == id);
            _context.Sabores.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
