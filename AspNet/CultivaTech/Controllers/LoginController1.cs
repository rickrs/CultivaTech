using Microsoft.AspNetCore.Mvc;
using CultivaTech.Data; // Namespace para o DbContext
using System.Linq; // Para métodos de consulta LINQ
using Microsoft.AspNetCore.Http; // Para gerenciamento de sessões

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
                // Salva o nome do usuário na sessão
                HttpContext.Session.SetString("UsuarioLogado", usuario.Nome);
                HttpContext.Session.SetString("TipoUsuario", usuario.Tipo);

                TempData["Mensagem"] = $"Bem-vindo, {usuario.Nome}!";
                return RedirectToAction("Index", "Dashboard"); // Redireciona para o DashboardController
            }
            else
            {
                // Define mensagem de erro no TempData
                TempData["Erro"] = "E-mail ou senha inválidos.";
                return View(); // Mantém a View atual
            }
        }

        // Processa o logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UsuarioLogado");
            TempData["Mensagem"] = "Você saiu do sistema.";
            return RedirectToAction("Index");
        }
    }
}
