using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuniChorrillos2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MuniChorrillos2.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly Bdmultas2Context _context;

        public EmpleadosController(Bdmultas2Context context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var empleados = await _context.Empleados.Include(e => e.IdTipoDocNavigation).ToListAsync();
            var tipoDocList = new SelectList(_context.TipoDocs, "IdTipoDoc", "Descripcion");
            ViewData["IdTipoDoc"] = tipoDocList;
            return View(empleados);
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdTipoDocNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["IdTipoDoc"] = new SelectList(_context.TipoDocs, "IdTipoDoc", "Descripcion");
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,NomEmpleado,ApellidoP,ApellidoM,Email,Telefono,Direccion,FechaIngreso,Activo,EstadoCivil,NroIdentidad,IdTipoDoc")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoDoc"] = new SelectList(_context.TipoDocs, "IdTipoDoc", "Descripcion", empleado.IdTipoDoc);
            return View(empleado);
        }

        // POST: Vmunicipals/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate([Bind("IdEmpleado,NomEmpleado,ApellidoP,ApellidoM,Email,Telefono,Direccion,FechaIngreso,Activo,EstadoCivil,NroIdentidad,IdTipoDoc")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                if (empleado.IdEmpleado == 0)
                {
                    _context.Add(empleado);
                }
                else
                {
                    _context.Update(empleado);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoDoc"] = new SelectList(_context.TipoDocs, "IdTipoDoc", "Descripcion", empleado.IdTipoDoc);
            return View(empleado.IdEmpleado == 0 ? "Create" : "Edit", empleado);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEstadoActivo(int id, int activo)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            empleado.Activo = (byte)activo; // Conversión explícita a byte
            _context.Update(empleado);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }



        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["IdTipoDoc"] = new SelectList(_context.TipoDocs, "IdTipoDoc", "Descripcion", empleado.IdTipoDoc);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,NomEmpleado,ApellidoP,ApellidoM,Email,Telefono,Direccion,FechaIngreso,Activo,EstadoCivil,NroIdentidad,IdTipoDoc")] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
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
            ViewData["IdTipoDoc"] = new SelectList(_context.TipoDocs, "IdTipoDoc", "Descripcion", empleado.IdTipoDoc);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdTipoDocNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}
