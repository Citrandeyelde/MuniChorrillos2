using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuniChorrillos2.Models;

namespace MuniChorrillos2.Controllers
{
    public class PersonalsController : Controller
    {
        private readonly Bdmultas2Context _context;

        public static string ConvertirSha256(string texto)
        {
            //using System.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public PersonalsController(Bdmultas2Context context)
        {
            _context = context;
        }

        // GET: Personals
        public async Task<IActionResult> Index()
        {
            var bdmultas2Context = _context.Personals.Include(p => p.IdAreaNavigation).Include(p => p.IdEmpleadoNavigation);
            return View(await bdmultas2Context.ToListAsync());
        }

        // GET: Personals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personals == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals
                .Include(p => p.IdAreaNavigation)
                .Include(p => p.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonal == id);
            if (personal == null)
            {
                return NotFound();
            }

            return View(personal);
        }

        // GET: Personals/Create
        public IActionResult Create()
        {
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "NomEmpleado");
            return View();
        }

        // POST: Personals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersonal,IdEmpleado,IdArea,UsuarioAcceso,Contraseña")] Personal personal)
        {
            personal.Contraseña = ConvertirSha256(personal.Contraseña);
            if (true)
            {
                _context.Add(personal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "IdArea", personal.IdArea);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", personal.IdEmpleado);
            return View(personal);
        }

        // GET: Personals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personals == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals.FindAsync(id);
            if (personal == null)
            {
                return NotFound();
            }
            
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "IdArea", personal.IdArea);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", personal.IdEmpleado);
            personal.Contraseña = ConvertirSha256(personal.Contraseña);
            return View(personal);
        }

        // POST: Personals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersonal,IdEmpleado,IdArea,UsuarioAcceso,Contraseña")] Personal personal)
        {
            if (id != personal.IdPersonal)
            {
                return NotFound();
            }

            if (ModelState.IsValid != true)
            {
                try
                {
                    _context.Update(personal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalExists(personal.IdPersonal))
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
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "IdArea", personal.IdArea);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", personal.IdEmpleado);
            return View(personal);
        }

        // GET: Personals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personals == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals
                .Include(p => p.IdAreaNavigation)
                .Include(p => p.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonal == id);
            if (personal == null)
            {
                return NotFound();
            }

            return View(personal);
        }

        // POST: Personals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personals == null)
            {
                return Problem("Entity set 'Bdmultas2Context.Personals'  is null.");
            }
            var personal = await _context.Personals.FindAsync(id);
            if (personal != null)
            {
                _context.Personals.Remove(personal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalExists(int id)
        {
          return (_context.Personals?.Any(e => e.IdPersonal == id)).GetValueOrDefault();
        }
    }
}
