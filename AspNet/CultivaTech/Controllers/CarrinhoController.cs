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

        // Exibe o resumo da compra
        public IActionResult ResumoCompra()
        {
            var clienteId = HttpContext.Session.GetInt32("UsuarioId");
            if (clienteId == null)
            {
                TempData["Erro"] = "Você precisa estar logado para visualizar o resumo da compra.";
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
                TempData["Erro"] = "Seu carrinho está vazio.";
                return RedirectToAction("Index");
            }

            ViewBag.Total = carrinho.Itens.Sum(i => i.Produto.Preco * i.Quantidade);
            return View(carrinho);
        }

        // Confirma e finaliza a compra
        [HttpPost]
        public IActionResult ConfirmarCompra()
        {
            var clienteId = HttpContext.Session.GetInt32("UsuarioId");
            if (clienteId == null)
            {
                TempData["Erro"] = "Você precisa estar logado para confirmar a compra.";
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
                TempData["Erro"] = "Seu carrinho está vazio.";
                return RedirectToAction("Index");
            }
            string numeroPedido = $"PED-{DateTime.Now:yyyyMMddHHmmss}-{clienteId}";

            // Cria o pedido
            var pedido = new Pedido
            {
                UsuarioId = clienteId.Value,
                Data = DateTime.Now,
                Status = "Pendente",
                Numero = numeroPedido,
                Itens = carrinho.Itens.Select(i => new ItemPedido
                {
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade
                }).ToList()
            };

            // Salva o pedido no banco
            _context.Pedidos.Add(pedido);

            // Remove os itens do carrinho
            var itensCarrinho = _context.ItensCarrinho.Where(i => i.CarrinhoId == carrinho.Id).ToList();
            _context.ItensCarrinho.RemoveRange(itensCarrinho);

            // Remove o carrinho
            _context.Carrinhos.Remove(carrinho);

            _context.SaveChanges();

            TempData["Mensagem"] = "Compra finalizada com sucesso!";
            return RedirectToAction("ConfirmacaoCompra", new { pedidoId = pedido.Id });
        }

        // Exibe a confirmação da compra
        public IActionResult ConfirmacaoCompra(int pedidoId)
        {
            var pedido = _context.Pedidos
                .Where(p => p.Id == pedidoId)
                .Select(p => new Pedido
                {
                    Id = p.Id,
                    UsuarioId = p.UsuarioId,
                    Data = p.Data,
                    Status = p.Status,
                    Itens = _context.ItensPedido
                        .Where(i => i.PedidoId == p.Id)
                        .Select(i => new ItemPedido
                        {
                            ProdutoId = i.ProdutoId,
                            Quantidade = i.Quantidade,
                            Produto = _context.Produtos.FirstOrDefault(prod => prod.Id == i.ProdutoId)
                        }).ToList()
                }).FirstOrDefault();

            if (pedido == null)
            {
                TempData["Erro"] = "Pedido não encontrado.";
                return RedirectToAction("Index", "Home");
            }

            return View(pedido);
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
