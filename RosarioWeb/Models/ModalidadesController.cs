using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RosarioWeb.Models
{
    public class ModalidadesController : Controller
    {
        private readonly dbRosarioContext _context;

        public ModalidadesController(dbRosarioContext context)
        {
            _context = context;
        }

        // GET: Modalidades
        public async Task<IActionResult> Index()
        {
            var dbRosarioContext = _context.Modalidad.Include(m => m.IdestudianteNavigation);
            return View(await dbRosarioContext.ToListAsync());
        }

        // GET: Modalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidad
                .Include(m => m.IdestudianteNavigation)
                .FirstOrDefaultAsync(m => m.Idmodalidad == id);
            if (modalidad == null)
            {
                return NotFound();
            }

            return View(modalidad);
        }

        // GET: Modalidades/Create
        public IActionResult Create()
        {
            ViewData["Idestudiante"] = new SelectList(_context.Estudiantes, "Idestudiante", "Idestudiante");
            return View();
        }

        // POST: Modalidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmodalidad,Idestudiante,Modalidad1")] Modalidad modalidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modalidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idestudiante"] = new SelectList(_context.Estudiantes, "Idestudiante", "Idestudiante", modalidad.Idestudiante);
            return View(modalidad);
        }

        // GET: Modalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidad.FindAsync(id);
            if (modalidad == null)
            {
                return NotFound();
            }
            ViewData["Idestudiante"] = new SelectList(_context.Estudiantes, "Idestudiante", "Idestudiante", modalidad.Idestudiante);
            return View(modalidad);
        }

        // POST: Modalidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmodalidad,Idestudiante,Modalidad1")] Modalidad modalidad)
        {
            if (id != modalidad.Idmodalidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modalidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModalidadExists(modalidad.Idmodalidad))
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
            ViewData["Idestudiante"] = new SelectList(_context.Estudiantes, "Idestudiante", "Idestudiante", modalidad.Idestudiante);
            return View(modalidad);
        }

        // GET: Modalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidad
                .Include(m => m.IdestudianteNavigation)
                .FirstOrDefaultAsync(m => m.Idmodalidad == id);
            if (modalidad == null)
            {
                return NotFound();
            }

            return View(modalidad);
        }

        // POST: Modalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modalidad = await _context.Modalidad.FindAsync(id);
            _context.Modalidad.Remove(modalidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModalidadExists(int id)
        {
            return _context.Modalidad.Any(e => e.Idmodalidad == id);
        }
    }
}
