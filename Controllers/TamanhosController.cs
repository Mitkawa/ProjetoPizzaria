using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Pizzaria.Data;
using Projeto_Pizzaria.Models;
using Projeto_Pizzaria.Models.ViewsModels.RequestDTO;
using System.Linq;

namespace Projeto_Pizzaria.Controllers
{
    public class TamanhosController : Controller
    {
        private PizzariaDbContext _context;
        public TamanhosController(PizzariaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Tamanhos);
        }

        public IActionResult Detalhes(int id)
        {
            var result = _context.Tamanhos.Include(T => T.Pizzas).FirstOrDefault(t => t.Id == id);

            if (result == null)
                return View("NotFound");

            return View(result);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostTamanhoDTO tamanhoDTO)
        {
            if (!ModelState.IsValid)
                return View(tamanhoDTO);

            Tamanho tamanho = new Tamanho(
                tamanhoDTO.Nome);

            _context.Tamanhos.Add(tamanho);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int? id)
        {
            if (id == null)
                return NotFound();

            var result = _context.Tamanhos.FirstOrDefault(t => t.Id == id);

            if (result == null)
                return View();

            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostTamanhoDTO tamanhoDTO)
        {
            var tamanho = _context.Tamanhos.FirstOrDefault(t => t.Id == id);

            if (!ModelState.IsValid)
                return View(tamanho);

            tamanho.AtualizarDados(tamanhoDTO.Nome);

            _context.Update(tamanho);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            var result = _context.Tamanhos.FirstOrDefault(t => t.Id == id);

            if (result == null)
                return View();

            return View(result);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Tamanhos.FirstOrDefault(t => t.Id == id);

            _context.Tamanhos.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
