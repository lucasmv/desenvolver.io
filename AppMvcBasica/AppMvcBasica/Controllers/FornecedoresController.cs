﻿using AppMvcBasica.Data;
using AppMvcBasica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcBasica.Controllers {
    public class FornecedoresController : Controller {
        private readonly ApplicationDbContext _context;

        public FornecedoresController(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            return View(await _context.Fornecedores.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id) {
            if (id == null) 
                return NotFound();

            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null) 
                return NotFound();

            return View(fornecedor);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fornecedor fornecedor) {
            if (ModelState.IsValid) {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        public async Task<IActionResult> Edit(Guid? id) {
            if (id == null)
                return NotFound();

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Fornecedor fornecedor) {
            if (id != fornecedor.Id)
                return NotFound();

            if (ModelState.IsValid) {
                try {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!FornecedorExists(fornecedor.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        public async Task<IActionResult> Delete(Guid? id) {
            if (id == null)
                return NotFound();

            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id) {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(Guid id) {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
