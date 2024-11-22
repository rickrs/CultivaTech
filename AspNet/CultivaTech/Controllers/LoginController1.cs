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
                // Salva o nome e tipo do usuário na sessão
                HttpContext.Session.SetString("UsuarioLogado", usuario.Nome);
                HttpContext.Session.SetString("TipoUsuario", usuario.Tipo);
                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);


                TempData["Mensagem"] = $"Bem-vindo, {usuario.Nome}!";

                // Redireciona para o Dashboard com base no tipo de usuário
                if (usuario.Tipo == "Admin")
                {
                    return RedirectToAction("Index", "Dashboard"); // Redireciona para a página de Admin
                }
                else if (usuario.Tipo == "Cliente")
                {
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            else
            {
                // Define mensagem de erro no TempData
                TempData["Erro"] = "E-mail ou senha inválidos.";
            }

            // Se não encontrou o usuário, ou se houve um erro de login, retorna para a página de login com mensagem de erro
            return View();
        }

        // Processa o logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UsuarioLogado");
            HttpContext.Session.Remove("TipoUsuario");
            TempData["Mensagem"] = "Você saiu do sistema.";
            return RedirectToAction("Index");
        }
    }
}
