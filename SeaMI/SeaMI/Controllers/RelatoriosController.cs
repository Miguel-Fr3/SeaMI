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
    public class RelatoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatoriosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Relatorios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Relatorios.Include(r => r.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Relatorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorios
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.cdRelatorio == id);
            if (relatorio == null)
            {
                return NotFound();
            }

            return View(relatorio);
        }

        // GET: Relatorios/Create
        public IActionResult Create()
        {
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsNacionalidade");
            return View();
        }

        // POST: Relatorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdRelatorio,nmRelatorio,dsRelatorio,dtRelatorio,cdUsuario")] Relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsNacionalidade", relatorio.cdUsuario);
            return View(relatorio);
        }

        // GET: Relatorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorios.FindAsync(id);
            if (relatorio == null)
            {
                return NotFound();
            }
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsNacionalidade", relatorio.cdUsuario);
            return View(relatorio);
        }

        // POST: Relatorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cdRelatorio,nmRelatorio,dsRelatorio,dtRelatorio,cdUsuario")] Relatorio relatorio)
        {
            if (id != relatorio.cdRelatorio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioExists(relatorio.cdRelatorio))
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
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsNacionalidade", relatorio.cdUsuario);
            return View(relatorio);
        }

        // GET: Relatorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorios
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.cdRelatorio == id);
            if (relatorio == null)
            {
                return NotFound();
            }

            return View(relatorio);
        }

        // POST: Relatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatorio = await _context.Relatorios.FindAsync(id);
            if (relatorio != null)
            {
                _context.Relatorios.Remove(relatorio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioExists(int id)
        {
            return _context.Relatorios.Any(e => e.cdRelatorio == id);
        }
    }
}
