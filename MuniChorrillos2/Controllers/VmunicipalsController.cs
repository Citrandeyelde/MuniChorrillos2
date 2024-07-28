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
    public class VmunicipalsController : Controller
    {
        private readonly Bdmultas2Context _context;

        public VmunicipalsController(Bdmultas2Context context)
        {
            _context = context;
        }

        // GET: Vmunicipals
        public async Task<IActionResult> Index()
        {
            var bdmultas2Context = _context.Vmunicipals.Include(v => v.IdPersonalNavigation);
            return View(await bdmultas2Context.ToListAsync());
        }

        // GET: Vmunicipals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vmunicipals == null)
            {
                return NotFound();
            }

            var vmunicipal = await _context.Vmunicipals
                .Include(v => v.IdPersonalNavigation)
                .FirstOrDefaultAsync(m => m.IdVehiculoMunicipal == id);
            if (vmunicipal == null)
            {
                return NotFound();
            }

            return View(vmunicipal);
        }

        // GET: Vmunicipals/Create
        public IActionResult Create()
        {
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal");
            return View();
        }

        // POST: Vmunicipals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVehiculoMunicipal,Placa,Marca,Modelo,Nmotor,Año,Color,Estado,IdPersonal")] Vmunicipal vmunicipal)
        {
            if (true)
            {
                _context.Add(vmunicipal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", vmunicipal.IdPersonal);
            return View(vmunicipal);
        }

        // GET: Vmunicipals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vmunicipals == null)
            {
                return NotFound();
            }

            var vmunicipal = await _context.Vmunicipals.FindAsync(id);
            if (vmunicipal == null)
            {
                return NotFound();
            }
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", vmunicipal.IdPersonal);
            return View(vmunicipal);
        }

        // POST: Vmunicipals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVehiculoMunicipal,Placa,Marca,Modelo,Nmotor,Año,Color,Estado,IdPersonal")] Vmunicipal vmunicipal)
        {
            if (id != vmunicipal.IdVehiculoMunicipal)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(vmunicipal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VmunicipalExists(vmunicipal.IdVehiculoMunicipal))
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
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", vmunicipal.IdPersonal);
            return View(vmunicipal);
        }

        // GET: Vmunicipals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vmunicipals == null)
            {
                return NotFound();
            }

            var vmunicipal = await _context.Vmunicipals
                .Include(v => v.IdPersonalNavigation)
                .FirstOrDefaultAsync(m => m.IdVehiculoMunicipal == id);
            if (vmunicipal == null)
            {
                return NotFound();
            }

            return View(vmunicipal);
        }

        // POST: Vmunicipals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vmunicipals == null)
            {
                return Problem("Entity set 'Bdmultas2Context.Vmunicipals'  is null.");
            }
            var vmunicipal = await _context.Vmunicipals.FindAsync(id);
            if (vmunicipal != null)
            {
                _context.Vmunicipals.Remove(vmunicipal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VmunicipalExists(int id)
        {
          return (_context.Vmunicipals?.Any(e => e.IdVehiculoMunicipal == id)).GetValueOrDefault();
        }
    }
}
