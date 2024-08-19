using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuniChorrillos2.Models;

namespace MuniChorrillos2.Controllers
{
    public class HorariosController : Controller
    {
        private readonly Bdmultas2Context _context;

        public HorariosController(Bdmultas2Context context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            var bdmultas2Context = _context.Horarios.Include(h => h.IdAreaNavigation).Include(h => h.IdEmpleadoNavigation);
            return View(await bdmultas2Context.ToListAsync());
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .Include(h => h.IdAreaNavigation)
                .Include(h => h.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdHorario == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "NomEmpleado");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHorario,IdEmpleado,IdArea,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,Hingreso,Hsalida")] Horario horario)
        {
            if (true)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "IdArea", horario.IdArea);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", horario.IdEmpleado);
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea", horario.IdArea);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "NomEmpleado", horario.IdEmpleado);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHorario,IdEmpleado,IdArea,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,Hingreso,Hsalida")] Horario horario)
        {
            if (id != horario.IdHorario)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.IdHorario))
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
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "IdArea", horario.IdArea);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", horario.IdEmpleado);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .Include(h => h.IdAreaNavigation)
                .Include(h => h.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdHorario == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Horarios == null)
            {
                return Problem("Entity set 'Bdmultas2Context.Horarios'  is null.");
            }
            var horario = await _context.Horarios.FindAsync(id);
            if (horario != null)
            {
                _context.Horarios.Remove(horario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
          return (_context.Horarios?.Any(e => e.IdHorario == id)).GetValueOrDefault();
        }
    }
}
