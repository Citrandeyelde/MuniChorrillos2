using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuniChorrillos2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MuniChorrillos2.Controllers
{
    public class DepositosController : Controller
    {
        private readonly Bdmultas2Context _context;

        public DepositosController(Bdmultas2Context context)
        {
            _context = context;
        }

        // GET: Depositos
        public async Task<IActionResult> Index()
        {
            var depositos = await _context.Depositos.Include(d => d.IdPersonalNavigation).ToListAsync();
            var personalsList = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso");
            ViewData["IdPersonal"] = personalsList;
            return View(depositos);
        }

        // GET: Depositos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Depositos == null)
            {
                return NotFound();
            }

            var deposito = await _context.Depositos
                .Include(d => d.IdPersonalNavigation)
                .FirstOrDefaultAsync(m => m.IdDeposito == id);
            if (deposito == null)
            {
                return NotFound();
            }

            return View(deposito);
        }

        // GET: Depositos/Create
        public IActionResult Create()
        {
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso");
            return View();
        }

        // POST: Depositos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDeposito,NomDeposito,Direccion,IdPersonal")] Deposito deposito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deposito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso", deposito.IdPersonal);
            return View(deposito);
        }

        // POST: Depositos/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate([Bind("IdDeposito,NomDeposito,Direccion,IdPersonal")] Deposito deposito)
        {
            if (ModelState.IsValid)
            {
                if (deposito.IdDeposito == 0)
                {
                    _context.Add(deposito);
                }
                else
                {
                    _context.Update(deposito);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso", deposito.IdPersonal);
            return View(deposito.IdDeposito == 0 ? "Create" : "Edit", deposito);
        }

        // GET: Depositos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Depositos == null)
            {
                return NotFound();
            }

            var deposito = await _context.Depositos.FindAsync(id);
            if (deposito == null)
            {
                return NotFound();
            }
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso", deposito.IdPersonal);
            return View(deposito);
        }

        // POST: Depositos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDeposito,NomDeposito,Direccion,IdPersonal")] Deposito deposito)
        {
            if (id != deposito.IdDeposito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deposito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepositoExists(deposito.IdDeposito))
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
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso", deposito.IdPersonal);
            return View(deposito);
        }

        // GET: Depositos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Depositos == null)
            {
                return NotFound();
            }

            var deposito = await _context.Depositos
                .Include(d => d.IdPersonalNavigation)
                .FirstOrDefaultAsync(m => m.IdDeposito == id);
            if (deposito == null)
            {
                return NotFound();
            }

            return View(deposito);
        }

        // POST: Depositos/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deposito = await _context.Depositos.FindAsync(id);
            if (deposito != null)
            {
                _context.Depositos.Remove(deposito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        private bool DepositoExists(int id)
        {
            return (_context.Depositos?.Any(e => e.IdDeposito == id)).GetValueOrDefault();
        }
    }
}
