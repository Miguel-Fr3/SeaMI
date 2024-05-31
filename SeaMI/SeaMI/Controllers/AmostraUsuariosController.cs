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
    public class AmostraUsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AmostraUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AmostraUsuarios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AmostraUsuarios.Include(a => a.AmostraAgua).Include(a => a.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AmostraUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amostraUsuario = await _context.AmostraUsuarios
                .Include(a => a.AmostraAgua)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.cdAmostraUser == id);
            if (amostraUsuario == null)
            {
                return NotFound();
            }

            return View(amostraUsuario);
        }

        // GET: AmostraUsuarios/Create
        public IActionResult Create()
        {
            ViewData["cdAmostra"] = new SelectList(_context.AmostraAguas, "cdAmostra", "dsConcentracaoPlastico");
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea");
            return View();
        }

        // POST: AmostraUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdAmostraUser,cdUsuario,cdAmostra,dsAmostra,dtAmostra")] AmostraUsuario amostraUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amostraUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cdAmostra"] = new SelectList(_context.AmostraAguas, "cdAmostra", "dsConcentracaoPlastico", amostraUsuario.cdAmostra);
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", amostraUsuario.cdUsuario);
            return View(amostraUsuario);
        }

        // GET: AmostraUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amostraUsuario = await _context.AmostraUsuarios.FindAsync(id);
            if (amostraUsuario == null)
            {
                return NotFound();
            }
            ViewData["cdAmostra"] = new SelectList(_context.AmostraAguas, "cdAmostra", "dsConcentracaoPlastico", amostraUsuario.cdAmostra);
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", amostraUsuario.cdUsuario);
            return View(amostraUsuario);
        }

        // POST: AmostraUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cdAmostraUser,cdUsuario,cdAmostra,dsAmostra,dtAmostra")] AmostraUsuario amostraUsuario)
        {
            if (id != amostraUsuario.cdAmostraUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amostraUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmostraUsuarioExists(amostraUsuario.cdAmostraUser))
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
            ViewData["cdAmostra"] = new SelectList(_context.AmostraAguas, "cdAmostra", "dsConcentracaoPlastico", amostraUsuario.cdAmostra);
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", amostraUsuario.cdUsuario);
            return View(amostraUsuario);
        }

        // GET: AmostraUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amostraUsuario = await _context.AmostraUsuarios
                .Include(a => a.AmostraAgua)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.cdAmostraUser == id);
            if (amostraUsuario == null)
            {
                return NotFound();
            }

            return View(amostraUsuario);
        }

        // POST: AmostraUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amostraUsuario = await _context.AmostraUsuarios.FindAsync(id);
            if (amostraUsuario != null)
            {
                _context.AmostraUsuarios.Remove(amostraUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmostraUsuarioExists(int id)
        {
            return _context.AmostraUsuarios.Any(e => e.cdAmostraUser == id);
        }
    }
}
