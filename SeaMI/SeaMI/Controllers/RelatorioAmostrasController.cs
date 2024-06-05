using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeaMI.Data;
using SeaMI.Models;

namespace SeaMI.Controllers
{
    public class RelatorioAmostrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatorioAmostrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RelatorioAmostras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RelatoriosAmostra.Include(r => r.AmostraAgua).Include(r => r.Relatorio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RelatorioAmostras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAmostra = await _context.RelatoriosAmostra
                .Include(r => r.AmostraAgua)
                .Include(r => r.Relatorio)
                .FirstOrDefaultAsync(m => m.cdRelatorioAmostra == id);
            if (relatorioAmostra == null)
            {
                return NotFound();
            }

            return View(relatorioAmostra);
        }

        // GET: RelatorioAmostras/Create
        public IActionResult Create()
        {
            ViewData["cdAmostra"] = new SelectList(_context.AmostrasAgua, "cdAmostra", "cdAmostra");
            ViewData["cdRelatorio"] = new SelectList(_context.Relatorios, "cdRelatorio", "nmRelatorio");
            return View();
        }

        // POST: RelatorioAmostras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdRelatorioAmostra,dsRelatorioAmostra,cdAmostra,cdRelatorio")] RelatorioAmostra relatorioAmostra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorioAmostra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cdAmostra"] = new SelectList(_context.AmostrasAgua, "cdAmostra", "cdAmostra", relatorioAmostra.cdAmostra);
            ViewData["cdRelatorio"] = new SelectList(_context.Relatorios, "cdRelatorio", "nmRelatorio", relatorioAmostra.cdRelatorio);
            return View(relatorioAmostra);
        }

        // GET: RelatorioAmostras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAmostra = await _context.RelatoriosAmostra.FindAsync(id);
            if (relatorioAmostra == null)
            {
                return NotFound();
            }
            ViewData["cdAmostra"] = new SelectList(_context.AmostrasAgua, "cdAmostra", "cdAmostra", relatorioAmostra.cdAmostra);
            ViewData["cdRelatorio"] = new SelectList(_context.Relatorios, "cdRelatorio", "nmRelatorio", relatorioAmostra.cdRelatorio);
            return View(relatorioAmostra);
        }

        // POST: RelatorioAmostras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cdRelatorioAmostra,dsRelatorioAmostra,cdAmostra,cdRelatorio")] RelatorioAmostra relatorioAmostra)
        {
            if (id != relatorioAmostra.cdRelatorioAmostra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorioAmostra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioAmostraExists(relatorioAmostra.cdRelatorioAmostra))
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
            ViewData["cdAmostra"] = new SelectList(_context.AmostrasAgua, "cdAmostra", "cdAmostra", relatorioAmostra.cdAmostra);
            ViewData["cdRelatorio"] = new SelectList(_context.Relatorios, "cdRelatorio", "nmRelatorio", relatorioAmostra.cdRelatorio);
            return View(relatorioAmostra);
        }

        // GET: RelatorioAmostras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAmostra = await _context.RelatoriosAmostra
                .Include(r => r.AmostraAgua)
                .Include(r => r.Relatorio)
                .FirstOrDefaultAsync(m => m.cdRelatorioAmostra == id);
            if (relatorioAmostra == null)
            {
                return NotFound();
            }

            return View(relatorioAmostra);
        }

        // POST: RelatorioAmostras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatorioAmostra = await _context.RelatoriosAmostra.FindAsync(id);
            if (relatorioAmostra != null)
            {
                _context.RelatoriosAmostra.Remove(relatorioAmostra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioAmostraExists(int id)
        {
            return _context.RelatoriosAmostra.Any(e => e.cdRelatorioAmostra == id);
        }
    }
}
