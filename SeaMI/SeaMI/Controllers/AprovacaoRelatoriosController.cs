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
    public class AprovacaoRelatoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AprovacaoRelatoriosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AprovacaoRelatorios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AprovacaoRelatorios.Include(a => a.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AprovacaoRelatorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aprovacaoRelatorio = await _context.AprovacaoRelatorios
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.cdAprovacao == id);
            if (aprovacaoRelatorio == null)
            {
                return NotFound();
            }

            return View(aprovacaoRelatorio);
        }

        // GET: AprovacaoRelatorios/Create
        public IActionResult Create()
        {
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea");
            return View();
        }

        // POST: AprovacaoRelatorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdAprovacao,cdUsuario,fgAprovado,dsComentario,dtAprovacao")] AprovacaoRelatorio aprovacaoRelatorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aprovacaoRelatorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", aprovacaoRelatorio.cdUsuario);
            return View(aprovacaoRelatorio);
        }

        // GET: AprovacaoRelatorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aprovacaoRelatorio = await _context.AprovacaoRelatorios.FindAsync(id);
            if (aprovacaoRelatorio == null)
            {
                return NotFound();
            }
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", aprovacaoRelatorio.cdUsuario);
            return View(aprovacaoRelatorio);
        }

        // POST: AprovacaoRelatorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cdAprovacao,cdUsuario,fgAprovado,dsComentario,dtAprovacao")] AprovacaoRelatorio aprovacaoRelatorio)
        {
            if (id != aprovacaoRelatorio.cdAprovacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aprovacaoRelatorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AprovacaoRelatorioExists(aprovacaoRelatorio.cdAprovacao))
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
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", aprovacaoRelatorio.cdUsuario);
            return View(aprovacaoRelatorio);
        }

        // GET: AprovacaoRelatorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aprovacaoRelatorio = await _context.AprovacaoRelatorios
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.cdAprovacao == id);
            if (aprovacaoRelatorio == null)
            {
                return NotFound();
            }

            return View(aprovacaoRelatorio);
        }

        // POST: AprovacaoRelatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aprovacaoRelatorio = await _context.AprovacaoRelatorios.FindAsync(id);
            if (aprovacaoRelatorio != null)
            {
                _context.AprovacaoRelatorios.Remove(aprovacaoRelatorio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AprovacaoRelatorioExists(int id)
        {
            return _context.AprovacaoRelatorios.Any(e => e.cdAprovacao == id);
        }
    }
}
