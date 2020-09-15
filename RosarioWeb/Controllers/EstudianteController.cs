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
    public class EstudianteController : Controller
    {
        private readonly dbRosarioContext _context;

        public EstudianteController(dbRosarioContext context)
        {
            _context = context;
        }

        // GET: Estudiante
        public async Task<IActionResult> Index()
        {
            var dbRosarioContext = _context.Estudiantes.Include(e => e.IdmateriaNavigation).Include(e => e.IdmatriculaNavigation).Include(e => e.IdnotaNavigation).Include(e => e.IdtutorNavigation);
            return View(await dbRosarioContext.ToListAsync());
        }

        // GET: Estudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes
                .Include(e => e.IdmateriaNavigation)
                .Include(e => e.IdmatriculaNavigation)
                .Include(e => e.IdnotaNavigation)
                .Include(e => e.IdtutorNavigation)
                .FirstOrDefaultAsync(m => m.Idestudiante == id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            return View(estudiantes);
        }

        // GET: Estudiante/Create
        public IActionResult Create()
        {
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria");
            ViewData["Idmatricula"] = new SelectList(_context.Matricula, "Idmatricula", "Idmatricula");
            ViewData["Idnota"] = new SelectList(_context.Notas, "Idnota", "Idnota");
            ViewData["Idtutor"] = new SelectList(_context.Tutor, "Idtutor", "Idtutor");
            return View();
        }

        // POST: Estudiante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idestudiante,Idmateria,Idtutor,Idmatricula,Idnota,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Sexo,Nacionalidad,Departamento,Domicilio")] Estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", estudiantes.Idmateria);
            ViewData["Idmatricula"] = new SelectList(_context.Matricula, "Idmatricula", "Idmatricula", estudiantes.Idmatricula);
            ViewData["Idnota"] = new SelectList(_context.Notas, "Idnota", "Idnota", estudiantes.Idnota);
            ViewData["Idtutor"] = new SelectList(_context.Tutor, "Idtutor", "Idtutor", estudiantes.Idtutor);
            return View(estudiantes);
        }

        // GET: Estudiante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes.FindAsync(id);
            if (estudiantes == null)
            {
                return NotFound();
            }
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", estudiantes.Idmateria);
            ViewData["Idmatricula"] = new SelectList(_context.Matricula, "Idmatricula", "Idmatricula", estudiantes.Idmatricula);
            ViewData["Idnota"] = new SelectList(_context.Notas, "Idnota", "Idnota", estudiantes.Idnota);
            ViewData["Idtutor"] = new SelectList(_context.Tutor, "Idtutor", "Idtutor", estudiantes.Idtutor);
            return View(estudiantes);
        }

        // POST: Estudiante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idestudiante,Idmateria,Idtutor,Idmatricula,Idnota,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Sexo,Nacionalidad,Departamento,Domicilio")] Estudiantes estudiantes)
        {
            if (id != estudiantes.Idestudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiantesExists(estudiantes.Idestudiante))
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
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", estudiantes.Idmateria);
            ViewData["Idmatricula"] = new SelectList(_context.Matricula, "Idmatricula", "Idmatricula", estudiantes.Idmatricula);
            ViewData["Idnota"] = new SelectList(_context.Notas, "Idnota", "Idnota", estudiantes.Idnota);
            ViewData["Idtutor"] = new SelectList(_context.Tutor, "Idtutor", "Idtutor", estudiantes.Idtutor);
            return View(estudiantes);
        }

        // GET: Estudiante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes
                .Include(e => e.IdmateriaNavigation)
                .Include(e => e.IdmatriculaNavigation)
                .Include(e => e.IdnotaNavigation)
                .Include(e => e.IdtutorNavigation)
                .FirstOrDefaultAsync(m => m.Idestudiante == id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            return View(estudiantes);
        }

        // POST: Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiantes = await _context.Estudiantes.FindAsync(id);
            _context.Estudiantes.Remove(estudiantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiantesExists(int id)
        {
            return _context.Estudiantes.Any(e => e.Idestudiante == id);
        }
    }
}
