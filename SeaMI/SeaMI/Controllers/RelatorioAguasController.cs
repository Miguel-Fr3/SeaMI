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
    public class RelatorioAguasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatorioAguasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RelatorioAguas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RelatorioAguas.Include(r => r.AprovacaoRelatorio).Include(r => r.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RelatorioAguas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAgua = await _context.RelatorioAguas
                .Include(r => r.AprovacaoRelatorio)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.cdRelatorio == id);
            if (relatorioAgua == null)
            {
                return NotFound();
            }

            return View(relatorioAgua);
        }

        // GET: RelatorioAguas/Create
        public IActionResult Create()
        {
            ViewData["cdAprovacao"] = new SelectList(_context.AprovacaoRelatorios, "cdAprovacao", "dsComentario");
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea");
            return View();
        }

        // POST: RelatorioAguas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdRelatorio,cdUsuario,cdAprovacao,dtRelatorio,dsRelatorio")] RelatorioAgua relatorioAgua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorioAgua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cdAprovacao"] = new SelectList(_context.AprovacaoRelatorios, "cdAprovacao", "dsComentario", relatorioAgua.cdAprovacao);
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", relatorioAgua.cdUsuario);
            return View(relatorioAgua);
        }

        // GET: RelatorioAguas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAgua = await _context.RelatorioAguas.FindAsync(id);
            if (relatorioAgua == null)
            {
                return NotFound();
            }
            ViewData["cdAprovacao"] = new SelectList(_context.AprovacaoRelatorios, "cdAprovacao", "dsComentario", relatorioAgua.cdAprovacao);
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", relatorioAgua.cdUsuario);
            return View(relatorioAgua);
        }

        // POST: RelatorioAguas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cdRelatorio,cdUsuario,cdAprovacao,dtRelatorio,dsRelatorio")] RelatorioAgua relatorioAgua)
        {
            if (id != relatorioAgua.cdRelatorio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorioAgua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioAguaExists(relatorioAgua.cdRelatorio))
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
            ViewData["cdAprovacao"] = new SelectList(_context.AprovacaoRelatorios, "cdAprovacao", "dsComentario", relatorioAgua.cdAprovacao);
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", relatorioAgua.cdUsuario);
            return View(relatorioAgua);
        }

        // GET: RelatorioAguas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAgua = await _context.RelatorioAguas
                .Include(r => r.AprovacaoRelatorio)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.cdRelatorio == id);
            if (relatorioAgua == null)
            {
                return NotFound();
            }

            return View(relatorioAgua);
        }

        // POST: RelatorioAguas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatorioAgua = await _context.RelatorioAguas.FindAsync(id);
            if (relatorioAgua != null)
            {
                _context.RelatorioAguas.Remove(relatorioAgua);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioAguaExists(int id)
        {
            return _context.RelatorioAguas.Any(e => e.cdRelatorio == id);
        }
    }
}
