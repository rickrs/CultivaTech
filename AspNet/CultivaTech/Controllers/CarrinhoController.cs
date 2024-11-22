using Microsoft.AspNetCore.Mvc;
using CultivaTech.Data;
using CultivaTech.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CultivaTech.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly CultivaTechContext _context;

        public CarrinhoController(CultivaTechContext context)
        {
            _context = context;
        }

        // Exibe o carrinho
        public IActionResult Index()
        {
            var clienteId = HttpContext.Session.GetInt32("UsuarioId");
            if (clienteId == null)
            {
                TempData["Erro"] = "Você precisa estar logado para acessar o carrinho.";
                return RedirectToAction("Index", "Login");
            }

            var carrinho = _context.Carrinhos
                .Where(c => c.UsuarioId == clienteId)
                .Select(c => new Carrinho
                {
                    Id = c.Id,
                    UsuarioId = c.UsuarioId,
                    Itens = _context.ItensCarrinho
                        .Where(i => i.CarrinhoId == c.Id)
                        .Select(i => new ItemCarrinho
                        {
                            Id = i.Id,
                            ProdutoId = i.ProdutoId,
                            Quantidade = i.Quantidade,
                            Produto = _context.Produtos.FirstOrDefault(p => p.Id == i.ProdutoId)
                        }).ToList()
                }).FirstOrDefault();

            if (carrinho == null || !carrinho.Itens.Any())
            {
                ViewBag.Mensagem = "Seu carrinho está vazio.";
                return View(new Carrinho());
            }

            return View(carrinho);
        }

        // Adiciona um item ao carrinho
        [HttpPost]
        public IActionResult Adicionar(int produto_id, int quantidade = 1)
        {
            var clienteId = HttpContext.Session.GetInt32("UsuarioId");
           

            if (clienteId == null)
            {
                TempData["Erro"] = "Você precisa estar logado para adicionar itens ao carrinho.";
                return RedirectToAction("Index", "Login");
            }

            var carrinho = _context.Carrinhos.FirstOrDefault(c => c.UsuarioId == clienteId);
            //var carrinho = _context.Carrinhos.FirstOrDefault(c => c.Cliente_Id == clienteId.Value);
            
            if (carrinho == null)
            {
                carrinho = new Carrinho { UsuarioId = clienteId.Value };
                _context.Carrinhos.Add(carrinho);
                _context.SaveChanges();
            }

            var itemCarrinho = _context.ItensCarrinho
                .FirstOrDefault(i => i.CarrinhoId == carrinho.Id && i.ProdutoId == produto_id);

            if (itemCarrinho == null)
            {
                itemCarrinho = new ItemCarrinho
                {
                    CarrinhoId = carrinho.Id,
                    ProdutoId = produto_id,
                    Quantidade = quantidade
                };
                _context.ItensCarrinho.Add(itemCarrinho);
            }
            else
            {
                itemCarrinho.Quantidade += quantidade;
                _context.ItensCarrinho.Update(itemCarrinho);
            }

            _context.SaveChanges();

            TempData["Mensagem"] = "Item adicionado ao carrinho!";
            return RedirectToAction("Index");
        }

        // Remove um item do carrinho
        [HttpPost]
        public IActionResult Remover(int itemCarrinhoId)
        {
            var itemCarrinho = _context.ItensCarrinho.Find(itemCarrinhoId);
            if (itemCarrinho != null)
            {
                _context.ItensCarrinho.Remove(itemCarrinho);
                _context.SaveChanges();
                TempData["Mensagem"] = "Item removido do carrinho!";
            }
            else
            {
                TempData["Erro"] = "Item não encontrado.";
            }

            return RedirectToAction("Index");
        }
    }
}
