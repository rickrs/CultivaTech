using Microsoft.AspNetCore.Mvc;
using CultivaTech.Data; // Namespace para o DbContext
using System.Linq; // Para métodos de consulta LINQ

namespace CultivaTech.Controllers
{
    public class LoginController : Controller
    {
        private readonly CultivaTechContext _context;

        // Construtor para injetar o contexto do banco de dados
        public LoginController(CultivaTechContext context)
        {
            _context = context;
        }

        // Exibe a página de login
        public IActionResult Index()
        {
            return View();
        }

        // Processa os dados do login
        [HttpPost]
        public IActionResult Index(string email, string senha)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
            {
                TempData["Mensagem"] = $"Bem-vindo, {usuario.Nome}!";
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Erro = "E-mail ou senha inválidos.";
                return View();
            }
        }

        // Exemplo de uma tela pós-login
        public IActionResult Dashboard()
        {
            ViewBag.Mensagem = TempData["Mensagem"];
            return View();
        }
    }
}
