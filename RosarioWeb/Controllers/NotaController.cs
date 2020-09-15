using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RosarioWeb.Models;

namespace RosarioWeb.Controllers
{
    public class NotaController : Controller
    {
        private readonly dbRosarioContext _context;

        public NotaController(dbRosarioContext context)
        {
            _context = context;
        }

        // GET: Nota
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notas.ToListAsync());
        }

        // GET: Nota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas
                .FirstOrDefaultAsync(m => m.Idnota == id);
            if (notas == null)
            {
                return NotFound();
            }

            return View(notas);
        }

        // GET: Nota/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnota,PrimerParcial,SegundoParcial,TercerParcial,NotaFinal")] Notas notas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notas);
        }

        // GET: Nota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas.FindAsync(id);
            if (notas == null)
            {
                return NotFound();
            }
            return View(notas);
        }

        // POST: Nota/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idnota,PrimerParcial,SegundoParcial,TercerParcial,NotaFinal")] Notas notas)
        {
            if (id != notas.Idnota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotasExists(notas.Idnota))
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
            return View(notas);
        }

        // GET: Nota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas
                .FirstOrDefaultAsync(m => m.Idnota == id);
            if (notas == null)
            {
                return NotFound();
            }

            return View(notas);
        }

        // POST: Nota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notas = await _context.Notas.FindAsync(id);
            _context.Notas.Remove(notas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotasExists(int id)
        {
            return _context.Notas.Any(e => e.Idnota == id);
        }
    }
}
