using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestePV.Data;
using TestePV.Models;

namespace TestePV.Controllers
{
    public class LeiturasController : Controller
    {
        private readonly TestePVContext _context;

        public LeiturasController(TestePVContext context)
        {
            _context = context;
        }

        // GET: Leituras
        public async Task<IActionResult> Index()
        {
            var testePVContext = _context.Leitura.Include(l => l.Leitor).Include(l => l.Livro);
            return View(await testePVContext.ToListAsync());
        }

        // GET: Leituras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leitura = await _context.Leitura
                .Include(l => l.Leitor)
                .Include(l => l.Livro)
                .FirstOrDefaultAsync(m => m.LeiturasId == id);
            if (leitura == null)
            {
                return NotFound();
            }

            return View(leitura);
        }

        // GET: Leituras/Create
        public IActionResult Create()
        {
            ViewData["LeitorId"] = new SelectList(_context.Leitor, "LeitorId", "LeitorNome");
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "LivroNome");
            return View();
        }

        // POST: Leituras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeiturasId,LeitorId,LivroId,Status")] Leitura leitura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leitura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeitorId"] = new SelectList(_context.Leitor, "LeitorId", "CPF", leitura.LeitorId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "LivroId", leitura.LivroId);
            return View(leitura);
        }

        // GET: Leituras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leitura = await _context.Leitura.FindAsync(id);
            if (leitura == null)
            {
                return NotFound();
            }
            ViewData["LeitorId"] = new SelectList(_context.Leitor, "LeitorId", "LeitorNome", leitura.LeitorId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "LivroNome", leitura.LivroId);
            return View(leitura);
        }

        // POST: Leituras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("LeiturasId,LeitorId,LivroId,Status")] Leitura leitura)
        {
            if (id != leitura.LeiturasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leitura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeituraExists(leitura.LeiturasId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeitorId"] = new SelectList(_context.Leitor, "LeitorId", "CPF", leitura.LeitorId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "LivroId", leitura.LivroId);
            return View(leitura);
        }

        // GET: Leituras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leitura = await _context.Leitura
                .Include(l => l.Leitor)
                .Include(l => l.Livro)
                .FirstOrDefaultAsync(m => m.LeiturasId == id);
            if (leitura == null)
            {
                return NotFound();
            }

            return View(leitura);
        }

        // POST: Leituras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var leitura = await _context.Leitura.FindAsync(id);
            _context.Leitura.Remove(leitura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeituraExists(int? id)
        {
            return _context.Leitura.Any(e => e.LeiturasId == id);
        }
    }
}
