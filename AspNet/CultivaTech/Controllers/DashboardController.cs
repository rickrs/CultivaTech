using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Para Sessões

namespace CultivaTech.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            // Verifica se o usuário está logado
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (usuarioLogado == null)
            {
                TempData["Erro"] = "Você precisa fazer login para acessar esta página.";
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Usuario = usuarioLogado;
            return View();
        }
    }
}
