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
    public class ProfesoreController : Controller
    {
        private readonly dbRosarioContext _context;

        public ProfesoreController(dbRosarioContext context)
        {
            _context = context;
        }

        // GET: Profesore
        public async Task<IActionResult> Index()
        {
            var dbRosarioContext = _context.Profesores.Include(p => p.IdmateriaNavigation);
            return View(await dbRosarioContext.ToListAsync());
        }

        // GET: Profesore/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesores = await _context.Profesores
                .Include(p => p.IdmateriaNavigation)
                .FirstOrDefaultAsync(m => m.Idprofesor == id);
            if (profesores == null)
            {
                return NotFound();
            }

            return View(profesores);
        }

        // GET: Profesore/Create
        public IActionResult Create()
        {
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria");
            return View();
        }

        // POST: Profesore/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idprofesor,Idmateria,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Sexo,Nacionalidad,Departamento,Domicilio,Telefono,Correo,Titulo,Inss")] Profesores profesores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", profesores.Idmateria);
            return View(profesores);
        }

        // GET: Profesore/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesores = await _context.Profesores.FindAsync(id);
            if (profesores == null)
            {
                return NotFound();
            }
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", profesores.Idmateria);
            return View(profesores);
        }

        // POST: Profesore/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idprofesor,Idmateria,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Sexo,Nacionalidad,Departamento,Domicilio,Telefono,Correo,Titulo,Inss")] Profesores profesores)
        {
            if (id != profesores.Idprofesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesoresExists(profesores.Idprofesor))
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
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", profesores.Idmateria);
            return View(profesores);
        }

        // GET: Profesore/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesores = await _context.Profesores
                .Include(p => p.IdmateriaNavigation)
                .FirstOrDefaultAsync(m => m.Idprofesor == id);
            if (profesores == null)
            {
                return NotFound();
            }

            return View(profesores);
        }

        // POST: Profesore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesores = await _context.Profesores.FindAsync(id);
            _context.Profesores.Remove(profesores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesoresExists(int id)
        {
            return _context.Profesores.Any(e => e.Idprofesor == id);
        }
    }
}
