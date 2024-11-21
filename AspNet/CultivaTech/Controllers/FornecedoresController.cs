using Microsoft.AspNetCore.Mvc;
using CultivaTech.Data; // Namespace do DbContext
using CultivaTech.Models; // Namespace do Model de Fornecedor
using System.Linq; // Para consultas LINQ
using System.Threading.Tasks; // Para métodos assíncronos

namespace CultivaTech.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly CultivaTechContext _context;

        // Injeta o DbContext no controlador
        public FornecedoresController(CultivaTechContext context)
        {
            _context = context;
        }

        // GET: Fornecedores
        public async Task<IActionResult> Index()
        {
            // Retorna todos os fornecedores
            var fornecedores = _context.Fornecedores.ToList();
            return View(fornecedores);
        }

        // GET: Fornecedores/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Contato,Endereco")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Fornecedor criado com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Contato,Endereco")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Fornecedor editado com sucesso!";
                }
                catch
                {
                    TempData["Erro"] = "Ocorreu um erro ao editar o fornecedor.";
                    return View(fornecedor);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Fornecedor excluído com sucesso!";
            }
            else
            {
                TempData["Erro"] = "Fornecedor não encontrado.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
