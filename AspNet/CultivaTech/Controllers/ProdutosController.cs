using Microsoft.AspNetCore.Mvc;
using CultivaTech.Data;
using CultivaTech.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CultivaTech.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly CultivaTechContext _context;

        public ProdutosController(CultivaTechContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco,QuantidadeEmEstoque")] Produto produto, IFormFile fotoProduto)
        {
            
                if (fotoProduto != null && fotoProduto.Length > 0)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    Directory.CreateDirectory(uploadsFolder); // Garante que a pasta exista

                    string uniqueFileName = Path.GetFileNameWithoutExtension(fotoProduto.FileName) +
                                            "_" + Path.GetRandomFileName().Substring(0, 8) +
                                            Path.GetExtension(fotoProduto.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await fotoProduto.CopyToAsync(stream);
                    }

                    produto.fotoProduto = uniqueFileName;
                }

                _context.Add(produto);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Produto criado com sucesso!";
                return RedirectToAction(nameof(Index));
           

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto, IFormFile fotoProduto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            

            try
            {
                // Se uma nova foto for enviada, salva no servidor e atualiza o campo FotoProduto
                if (fotoProduto != null && fotoProduto.Length > 0)
                {
                    
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                    string uniqueFileName = Path.GetFileNameWithoutExtension(fotoProduto.FileName) +
                                            "_" + Path.GetRandomFileName().Substring(0, 8) +
                                            Path.GetExtension(fotoProduto.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await fotoProduto.CopyToAsync(stream);
                    }

                    // Atualiza o caminho da foto no modelo
                    produto.fotoProduto = uniqueFileName;
                }

                _context.Update(produto);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Produto editado com sucesso!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao editar produto: {ex.Message}");
                TempData["Erro"] = "Erro ao editar o produto.";
                return View(produto);
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Produto excluído com sucesso!";
            }
            else
            {
                TempData["Erro"] = "Produto não encontrado.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
