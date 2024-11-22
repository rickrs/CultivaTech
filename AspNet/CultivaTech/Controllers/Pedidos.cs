using Microsoft.AspNetCore.Mvc;
using CultivaTech.Data;
using CultivaTech.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CultivaTech.Controllers
{
    public class PedidosController : Controller
    {
        private readonly CultivaTechContext _context;

        public PedidosController(CultivaTechContext context)
        {
            _context = context;
        }

        // Exibe os pedidos do cliente logado
        public IActionResult Index()
        {
            var clienteId = HttpContext.Session.GetInt32("UsuarioId");
            if (clienteId == null)
            {
                TempData["Erro"] = "Você precisa estar logado para acessar seus pedidos.";
                return RedirectToAction("Index", "Login");
            }

            var pedidos = _context.Pedidos
                .Where(p => p.UsuarioId == clienteId)
                .Select(p => new Pedido
                {
                    Id = p.Id,
                    Numero = p.Numero,
                    Data = p.Data,
                    Status = p.Status,
                    Itens = _context.ItensPedido
                        .Where(i => i.PedidoId == p.Id)
                        .Select(i => new ItemPedido
                        {
                            Produto = _context.Produtos.FirstOrDefault(pr => pr.Id == i.ProdutoId),
                            Quantidade = i.Quantidade
                        }).ToList()
                }).ToList();

            return View(pedidos);
        }
    }
}
