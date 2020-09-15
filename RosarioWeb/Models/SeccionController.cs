using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RosarioWeb.Models
{
    public class SeccionController : Controller
    {
        private readonly dbRosarioContext _context;

        public SeccionController(dbRosarioContext context)
        {
            _context = context;
        }

        // GET: Seccion
        public async Task<IActionResult> Index()
        {
            var dbRosarioContext = _context.Secciones.Include(s => s.IdestudianteNavigation);
            return View(await dbRosarioContext.ToListAsync());
        }

        // GET: Seccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secciones = await _context.Secciones
                .Include(s => s.IdestudianteNavigation)
                .FirstOrDefaultAsync(m => m.Idseccion == id);
            if (secciones == null)
            {
                return NotFound();
            }

            return View(secciones);
        }

        // GET: Seccion/Create
        public IActionResult Create()
        {
            ViewData["Idestudiante"] = new SelectList(_context.Estudiantes, "Idestudiante", "Idestudiante");
            return View();
        }

        // POST: Seccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idseccion,Idestudiante,Seccion")] Secciones secciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(secciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idestudiante"] = new SelectList(_context.Estudiantes, "Idestudiante", "Idestudiante", secciones.Idestudiante);
            return View(secciones);
        }

        // GET: Seccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secciones = await _context.Secciones.FindAsync(id);
            if (secciones == null)
            {
                return NotFound();
            }
            ViewData["Idestudiante"] = new SelectList(_context.Estudiantes, "Idestudiante", "Idestudiante", secciones.Idestudiante);
            return View(secciones);
        }

        // POST: Seccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idseccion,Idestudiante,Seccion")] Secciones secciones)
        {
            if (id != secciones.Idseccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(secciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeccionesExists(secciones.Idseccion))
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
            ViewData["Idestudiante"] = new SelectList(_context.Estudiantes, "Idestudiante", "Idestudiante", secciones.Idestudiante);
            return View(secciones);
        }

        // GET: Seccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secciones = await _context.Secciones
                .Include(s => s.IdestudianteNavigation)
                .FirstOrDefaultAsync(m => m.Idseccion == id);
            if (secciones == null)
            {
                return NotFound();
            }

            return View(secciones);
        }

        // POST: Seccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var secciones = await _context.Secciones.FindAsync(id);
            _context.Secciones.Remove(secciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeccionesExists(int id)
        {
            return _context.Secciones.Any(e => e.Idseccion == id);
        }
    }
}
