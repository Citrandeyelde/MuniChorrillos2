using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuniChorrillos2.Models;
using System.Linq;
using System.Threading.Tasks;

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
            var vehiculosMunicipales = await _context.Vmunicipals.Include(v => v.IdPersonalNavigation).ToListAsync();
            var personalsList = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso");
            ViewData["IdPersonal"] = personalsList;
            return View(vehiculosMunicipales);
            /*var bdmultas2Context = _context.Vmunicipals.Include(v => v.IdPersonalNavigation);
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso");
       
            return View(await bdmultas2Context.ToListAsync());*/
            /*var vehiculosMunicipales = await _context.Vmunicipals.Include(v => v.IdPersonalNavigation).ToListAsync();
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso");
            return View(vehiculosMunicipales);*/
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
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso");
            /*ViewBag.IdPersonal = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso");*/
            return View();
        }

        // POST: Vmunicipals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVehiculoMunicipal,Placa,Marca,Modelo,Nmotor,Año,Color,Estado,IdPersonal")] Vmunicipal vmunicipal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vmunicipal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso", vmunicipal.IdPersonal);
            /*ViewBag.IdPersonal = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso", vmunicipal.IdPersonal);*/
            return View(vmunicipal);
        }

        // POST: Vmunicipals/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate([Bind("IdVehiculoMunicipal,Placa,Marca,Modelo,Nmotor,Año,Color,Estado,IdPersonal")] Vmunicipal vmunicipal)
        {
            if (ModelState.IsValid)
            {
                if (vmunicipal.IdVehiculoMunicipal == 0)
                {
                    _context.Add(vmunicipal);
                }
                else
                {
                    _context.Update(vmunicipal);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso", vmunicipal.IdPersonal);
            return View(vmunicipal.IdVehiculoMunicipal == 0 ? "Create" : "Edit", vmunicipal);
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
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso", vmunicipal.IdPersonal);
            return View(vmunicipal);
        }

        // POST: Vmunicipals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVehiculoMunicipal,Placa,Marca,Modelo,Nmotor,Año,Color,Estado,IdPersonal")] Vmunicipal vmunicipal)
        {
            if (id != vmunicipal.IdVehiculoMunicipal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
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
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso", vmunicipal.IdPersonal);
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
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vmunicipal = await _context.Vmunicipals.FindAsync(id);
            if (vmunicipal != null)
            {
                _context.Vmunicipals.Remove(vmunicipal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        private bool VmunicipalExists(int id)
        {
            return (_context.Vmunicipals?.Any(e => e.IdVehiculoMunicipal == id)).GetValueOrDefault();
        }
    }
}
