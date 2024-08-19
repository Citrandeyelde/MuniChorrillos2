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

        public PersonalsController(Bdmultas2Context context)
        {
            _context = context;
        }

        private static string ConvertirSha256(string texto)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(texto));
                return string.Concat(bytes.Select(b => b.ToString("x2")));
            }
        }

        // GET: Personals
        public async Task<IActionResult> Index()
        {
            var personalAdministrativo = await _context.Personals
                .Include(p => p.IdEmpleadoNavigation)
                .Include(p => p.IdAreaNavigation)
                .ToListAsync();

            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "NomEmpleado");
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea");

            return View(personalAdministrativo);
        }

        // GET: Personals/Create
        public IActionResult Create()
        {
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "NomEmpleado");
            return View();
        }

        // POST: Personals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersonal,IdEmpleado,IdArea,UsuarioAcceso,Contraseña")] Personal personal)
        {
            personal.Contraseña = ConvertirSha256(personal.Contraseña);
            if (ModelState.IsValid)
            {
                _context.Add(personal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "IdArea", personal.IdArea);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", personal.IdEmpleado);
            return View(personal);
        }

        // POST: Personals/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate([Bind("IdPersonal,IdEmpleado,IdArea,UsuarioAcceso,Contraseña")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                if (personal.IdPersonal == 0)
                {
                    personal.Contraseña = ConvertirSha256(personal.Contraseña);
                    _context.Add(personal);
                }
                else
                {
                    var existingPersonal = await _context.Personals.FindAsync(personal.IdPersonal);
                    if (existingPersonal == null)
                    {
                        return NotFound();
                    }

                    existingPersonal.IdEmpleado = personal.IdEmpleado;
                    existingPersonal.IdArea = personal.IdArea;
                    existingPersonal.UsuarioAcceso = personal.UsuarioAcceso;

                    if (!string.IsNullOrWhiteSpace(personal.Contraseña))
                    {
                        existingPersonal.Contraseña = ConvertirSha256(personal.Contraseña);
                    }

                    _context.Update(existingPersonal);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea", personal.IdArea);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "NomEmpleado", personal.IdEmpleado);
            return View(personal.IdPersonal == 0 ? "Create" : "Edit", personal);
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

            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea", personal.IdArea);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "NomEmpleado", personal.IdEmpleado);
            return View(personal);
        }

        // POST: Personals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersonal,IdEmpleado,IdArea,UsuarioAcceso,Contraseña")] Personal personal)
        {
            if (id != personal.IdPersonal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingPersonal = await _context.Personals.FindAsync(personal.IdPersonal);
                    if (existingPersonal == null)
                    {
                        return NotFound();
                    }

                    existingPersonal.IdEmpleado = personal.IdEmpleado;
                    existingPersonal.IdArea = personal.IdArea;
                    existingPersonal.UsuarioAcceso = personal.UsuarioAcceso;

                    if (!string.IsNullOrWhiteSpace(personal.Contraseña))
                    {
                        existingPersonal.Contraseña = ConvertirSha256(personal.Contraseña);
                    }

                    _context.Update(existingPersonal);
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
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea", personal.IdArea);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "NomEmpleado", personal.IdEmpleado);
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
        [HttpPost, ActionName("DeleteConfirmed")]
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
            return _context.Personals.Any(e => e.IdPersonal == id);
        }
    }
}
