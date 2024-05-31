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
    public class MonitoramentoAguasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonitoramentoAguasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MonitoramentoAguas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MonitoramentoAguas.Include(m => m.AmostraAgua).Include(m => m.Sensores);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MonitoramentoAguas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitoramentoAgua = await _context.MonitoramentoAguas
                .Include(m => m.AmostraAgua)
                .Include(m => m.Sensores)
                .FirstOrDefaultAsync(m => m.cdMonitoramentoAgua == id);
            if (monitoramentoAgua == null)
            {
                return NotFound();
            }

            return View(monitoramentoAgua);
        }

        // GET: MonitoramentoAguas/Create
        public IActionResult Create()
        {
            ViewData["cdAmostra"] = new SelectList(_context.AmostraAguas, "cdAmostra", "dsConcentracaoPlastico");
            ViewData["cdSensor"] = new SelectList(_context.Sensores, "cdSensor", "dsSensor");
            return View();
        }

        // POST: MonitoramentoAguas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdMonitoramentoAgua,cdSensor,cdAmostra,dsMonitoramento")] MonitoramentoAgua monitoramentoAgua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monitoramentoAgua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cdAmostra"] = new SelectList(_context.AmostraAguas, "cdAmostra", "dsConcentracaoPlastico", monitoramentoAgua.cdAmostra);
            ViewData["cdSensor"] = new SelectList(_context.Sensores, "cdSensor", "dsSensor", monitoramentoAgua.cdSensor);
            return View(monitoramentoAgua);
        }

        // GET: MonitoramentoAguas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitoramentoAgua = await _context.MonitoramentoAguas.FindAsync(id);
            if (monitoramentoAgua == null)
            {
                return NotFound();
            }
            ViewData["cdAmostra"] = new SelectList(_context.AmostraAguas, "cdAmostra", "dsConcentracaoPlastico", monitoramentoAgua.cdAmostra);
            ViewData["cdSensor"] = new SelectList(_context.Sensores, "cdSensor", "dsSensor", monitoramentoAgua.cdSensor);
            return View(monitoramentoAgua);
        }

        // POST: MonitoramentoAguas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cdMonitoramentoAgua,cdSensor,cdAmostra,dsMonitoramento")] MonitoramentoAgua monitoramentoAgua)
        {
            if (id != monitoramentoAgua.cdMonitoramentoAgua)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monitoramentoAgua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonitoramentoAguaExists(monitoramentoAgua.cdMonitoramentoAgua))
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
            ViewData["cdAmostra"] = new SelectList(_context.AmostraAguas, "cdAmostra", "dsConcentracaoPlastico", monitoramentoAgua.cdAmostra);
            ViewData["cdSensor"] = new SelectList(_context.Sensores, "cdSensor", "dsSensor", monitoramentoAgua.cdSensor);
            return View(monitoramentoAgua);
        }

        // GET: MonitoramentoAguas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitoramentoAgua = await _context.MonitoramentoAguas
                .Include(m => m.AmostraAgua)
                .Include(m => m.Sensores)
                .FirstOrDefaultAsync(m => m.cdMonitoramentoAgua == id);
            if (monitoramentoAgua == null)
            {
                return NotFound();
            }

            return View(monitoramentoAgua);
        }

        // POST: MonitoramentoAguas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monitoramentoAgua = await _context.MonitoramentoAguas.FindAsync(id);
            if (monitoramentoAgua != null)
            {
                _context.MonitoramentoAguas.Remove(monitoramentoAgua);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonitoramentoAguaExists(int id)
        {
            return _context.MonitoramentoAguas.Any(e => e.cdMonitoramentoAgua == id);
        }
    }
}
