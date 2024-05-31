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
    public class SensoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SensoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sensores
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sensores.Include(s => s.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sensores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensores = await _context.Sensores
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.cdSensor == id);
            if (sensores == null)
            {
                return NotFound();
            }

            return View(sensores);
        }

        // GET: Sensores/Create
        public IActionResult Create()
        {
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea");
            return View();
        }

        // POST: Sensores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdSensor,cdUsuario,nmTecnologia,dsSensor,dtImplementacao")] Sensores sensores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sensores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", sensores.cdUsuario);
            return View(sensores);
        }

        // GET: Sensores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensores = await _context.Sensores.FindAsync(id);
            if (sensores == null)
            {
                return NotFound();
            }
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", sensores.cdUsuario);
            return View(sensores);
        }

        // POST: Sensores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cdSensor,cdUsuario,nmTecnologia,dsSensor,dtImplementacao")] Sensores sensores)
        {
            if (id != sensores.cdSensor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sensores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SensoresExists(sensores.cdSensor))
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
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "dsArea", sensores.cdUsuario);
            return View(sensores);
        }

        // GET: Sensores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensores = await _context.Sensores
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.cdSensor == id);
            if (sensores == null)
            {
                return NotFound();
            }

            return View(sensores);
        }

        // POST: Sensores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sensores = await _context.Sensores.FindAsync(id);
            if (sensores != null)
            {
                _context.Sensores.Remove(sensores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SensoresExists(int id)
        {
            return _context.Sensores.Any(e => e.cdSensor == id);
        }
    }
}
