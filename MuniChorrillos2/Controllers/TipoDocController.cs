using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuniChorrillos2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MuniChorrillos2.Controllers
{
    public class TipoDocController : Controller
    {
        private readonly Bdmultas2Context _context;

        public TipoDocController(Bdmultas2Context context)
        {
            _context = context;
        }

        // GET: TipoDoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDocs.ToListAsync());
        }

        // GET: TipoDoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoDocs == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDocs
                .FirstOrDefaultAsync(m => m.IdTipoDoc == id);
            if (tipoDoc == null)
            {
                return NotFound();
            }

            return View(tipoDoc);
        }

        // GET: TipoDoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDoc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoDoc,Descripcion,NumIdentifica")] TipoDoc tipoDoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDoc);
        }

        // POST: TipoDoc/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate([Bind("IdTipoDoc,Descripcion,NumIdentifica")] TipoDoc tipoDoc)
        {
            if (ModelState.IsValid)
            {
                if (tipoDoc.IdTipoDoc == 0)
                {
                    _context.Add(tipoDoc);
                }
                else
                {
                    _context.Update(tipoDoc);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDoc.IdTipoDoc == 0 ? "Create" : "Edit", tipoDoc);
        }


        // GET: TipoDoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoDocs == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDocs.FindAsync(id);
            if (tipoDoc == null)
            {
                return NotFound();
            }
            return View(tipoDoc);
        }

        // POST: TipoDoc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoDoc,Descripcion,NumIdentifica")] TipoDoc tipoDoc)
        {
            if (id != tipoDoc.IdTipoDoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocExists(tipoDoc.IdTipoDoc))
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
            return View(tipoDoc);
        }

        // GET: TipoDoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoDocs == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDocs
                .FirstOrDefaultAsync(m => m.IdTipoDoc == id);
            if (tipoDoc == null)
            {
                return NotFound();
            }

            return View(tipoDoc);
        }

        // POST: TipoDoc/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDoc = await _context.TipoDocs.FindAsync(id);
            if (tipoDoc != null)
            {
                _context.TipoDocs.Remove(tipoDoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }


        private bool TipoDocExists(int id)
        {
            return (_context.TipoDocs?.Any(e => e.IdTipoDoc == id)).GetValueOrDefault();
        }
    }
}
