using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeaMI.Data;
using SeaMI.Models;

namespace SeaMI.Controllers
{
    public class LoginsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Logins
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Logins.Include(l => l.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Logins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Logins
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.cdLogin == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Logins/Create
        public IActionResult Create()
        {
            ViewBag.Usuarios = _context.Usuarios.ToList();
            return View();

        }

        // POST: Logins/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdLogin,dsEmail,dsSenha,cdUsuario")] Login login)
        {
            try
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

            }
            return View(login);
        }

        // GET: Logins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            ViewData["cdUsuario"] = new SelectList(_context.Usuarios, "cdUsuario", "nmUsuario", login.cdUsuario);
            return View(login);
        }

        // POST: Logins/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cdLogin,dsEmail,dsSenha,cdUsuario")] Login login)
        {
            try
            {
                _context.Update(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

            }
            return View(login);
        }



        // GET: Logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Logins
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.cdLogin == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var login = await _context.Logins.FindAsync(id);
            if (login != null)
            {
                _context.Logins.Remove(login);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginExists(int id)
        {
            return _context.Logins.Any(e => e.cdLogin == id);
        }
    }
}
