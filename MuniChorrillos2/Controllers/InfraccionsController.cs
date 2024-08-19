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
    public class InfraccionsController : Controller
    {
        private readonly Bdmultas2Context _context;

        public InfraccionsController(Bdmultas2Context context)
        {
            _context = context;
        }

        // GET: Infraccions
        public async Task<IActionResult> Index()
        {
            return _context.Infraccions != null ?
                        View(await _context.Infraccions.ToListAsync()) :
                        Problem("Entity set 'Bdmultas2Context.Infraccions'  is null.");
        }

        // GET: Infraccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Infraccions == null)
            {
                return NotFound();
            }

            var infraccion = await _context.Infraccions
                .FirstOrDefaultAsync(m => m.IdInfraccion == id);
            if (infraccion == null)
            {
                return NotFound();
            }

            return View(infraccion);
        }

        // GET: Infraccions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Infraccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInfraccion,NomInfraccion,Descripcion,Resolucion,Rango,Monto")] Infraccion infraccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infraccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infraccion);
        }

        // POST: Infraccions/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate([Bind("IdInfraccion,NomInfraccion,Descripcion,Resolucion,Rango,Monto")] Infraccion infraccion)
        {
            if (ModelState.IsValid)
            {
                if (infraccion.IdInfraccion == 0)
                {
                    _context.Add(infraccion);
                }
                else
                {
                    _context.Update(infraccion);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(infraccion.IdInfraccion == 0 ? "Create" : "Edit", infraccion);
        }


        // GET: Infraccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Infraccions == null)
            {
                return NotFound();
            }

            var infraccion = await _context.Infraccions.FindAsync(id);
            if (infraccion == null)
            {
                return NotFound();
            }
            return View(infraccion);
        }

        // POST: Infraccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInfraccion,NomInfraccion,Descripcion,Resolucion,Rango,Monto")] Infraccion infraccion)
        {
            if (id != infraccion.IdInfraccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infraccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfraccionExists(infraccion.IdInfraccion))
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
            return View(infraccion);
        }

        // GET: Infraccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Infraccions == null)
            {
                return NotFound();
            }

            var infraccion = await _context.Infraccions
                .FirstOrDefaultAsync(m => m.IdInfraccion == id);
            if (infraccion == null)
            {
                return NotFound();
            }

            return View(infraccion);
        }

        // POST: Infraccions/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Infraccions == null)
            {
                return Problem("Entity set 'Bdmultas2Context.Infraccions'  is null.");
            }
            var infraccion = await _context.Infraccions.FindAsync(id);
            if (infraccion != null)
            {
                _context.Infraccions.Remove(infraccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfraccionExists(int id)
        {
          return (_context.Infraccions?.Any(e => e.IdInfraccion == id)).GetValueOrDefault();
        }
    }
}
