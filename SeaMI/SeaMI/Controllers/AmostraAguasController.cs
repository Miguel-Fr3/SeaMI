﻿using System;
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
    public class AmostraAguasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AmostraAguasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AmostraAguas
        public async Task<IActionResult> Index()
        {
            return View(await _context.AmostraAguas.ToListAsync());
        }

        // GET: AmostraAguas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amostraAgua = await _context.AmostraAguas
                .FirstOrDefaultAsync(m => m.cdAmostra == id);
            if (amostraAgua == null)
            {
                return NotFound();
            }

            return View(amostraAgua);
        }

        // GET: AmostraAguas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AmostraAguas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdAmostra,dtColeta,dsPH,dsPoluentesQuimicos,dsNutrientes,dsConcentracaoPlastico,dsOxigenioDissolvido,dsTemperatura,dsTurbidez")] AmostraAgua amostraAgua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amostraAgua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amostraAgua);
        }

        // GET: AmostraAguas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amostraAgua = await _context.AmostraAguas.FindAsync(id);
            if (amostraAgua == null)
            {
                return NotFound();
            }
            return View(amostraAgua);
        }

        // POST: AmostraAguas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cdAmostra,dtColeta,dsPH,dsPoluentesQuimicos,dsNutrientes,dsConcentracaoPlastico,dsOxigenioDissolvido,dsTemperatura,dsTurbidez")] AmostraAgua amostraAgua)
        {
            if (id != amostraAgua.cdAmostra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amostraAgua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmostraAguaExists(amostraAgua.cdAmostra))
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
            return View(amostraAgua);
        }

        // GET: AmostraAguas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amostraAgua = await _context.AmostraAguas
                .FirstOrDefaultAsync(m => m.cdAmostra == id);
            if (amostraAgua == null)
            {
                return NotFound();
            }

            return View(amostraAgua);
        }

        // POST: AmostraAguas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amostraAgua = await _context.AmostraAguas.FindAsync(id);
            if (amostraAgua != null)
            {
                _context.AmostraAguas.Remove(amostraAgua);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmostraAguaExists(int id)
        {
            return _context.AmostraAguas.Any(e => e.cdAmostra == id);
        }
    }
}