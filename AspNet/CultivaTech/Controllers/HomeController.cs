using Microsoft.AspNetCore.Mvc;
using CultivaTech.Data;
using System.Linq;

namespace CultivaTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly CultivaTechContext _context;

        public HomeController(CultivaTechContext context)
        {
            _context = context;
        }

        // GET: Home/Dashboard
        public IActionResult Dashboard()
        {
            // Carrega os produtos da tabela Produtos
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }
    }
}
