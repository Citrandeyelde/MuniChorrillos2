using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuniChorrillos2.Models;
using MuniChorrillos2.Servicios;

namespace MuniChorrillos2.Controllers
{
    public class SistemaPagosController : Controller
    {
        private readonly Bdmultas2Context _context;
        private readonly StripeService _stripeService;

        public SistemaPagosController(Bdmultas2Context context, StripeService stripeService)
        {
            _context = context;
            _stripeService = stripeService;
        }

        // GET: MultasController
        public async Task<IActionResult> Index()
        {
            var multas = await _context.Multa
                .Include(m => m.IdDepositoNavigation)
                .Include(m => m.IdInfraccionNavigation)
            .Include(m => m.IdPersonalNavigation)
                .ToListAsync();
            ViewData["IdDeposito"] = new SelectList(_context.Depositos, "IdDeposito", "NomDeposito");
            ViewData["IdInfraccion"] = new SelectList(_context.Infraccions, "IdInfraccion", "Descripcion");
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso");
            return View(multas);
        }

        // POST: MultasController/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate([Bind("IdMulta,FecMulta,HoraMulta,LugarMulta,DistritoMulta,NroSerie,Placa,Marca,Modelo,Nmotor,Año,Color,Estado,Propietario,Email,Direcion,Grua,IdDeposito,IdInfraccion,IdPersonal,EstPago,CodPago,Telefono,Observaciones,Imagen,ImagenBase64")] Multum multa)
        {
            if (ModelState.IsValid)
            {
                if (multa.IdMulta == 0)
                {
                    _context.Add(multa);

                }
                else
                {
                    _context.Update(multa);

                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDeposito"] = new SelectList(_context.Depositos, "IdDeposito", "NomDeposito", multa.IdDeposito);
            ViewData["IdInfraccion"] = new SelectList(_context.Infraccions, "IdInfraccion", "Descripcion", multa.IdInfraccion);
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "IdPersonal", "UsuarioAcceso", multa.IdPersonal);
            return View("Index", multa);
        }

        // GET: MultasController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multa = await _context.Multa
                .Include(m => m.IdDepositoNavigation)
                .Include(m => m.IdInfraccionNavigation)
                .Include(m => m.IdPersonalNavigation)
                .FirstOrDefaultAsync(m => m.IdMulta == id);

            if (multa == null)
            {
                return NotFound();
            }

            return View(multa);
        }

        // POST: MultasController/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var multa = await _context.Multa.FindAsync(id);
            _context.Multa.Remove(multa);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Multa eliminada con éxito";
            return RedirectToAction(nameof(Index));
        }

        private bool MultaExists(int id)
        {
            return _context.Multa.Any(e => e.IdMulta == id);
        }

        // Redirección a otra área (por ejemplo)
        public IActionResult RedirectToExternal()
        {
            return RedirectToAction("Index", "Areas");
        }

        //Para los pagos
        public async Task<IActionResult> Pagar(int idMulta)
        {
            var multa = await _context.Multa.FindAsync(idMulta);

            if (multa == null)
            {
                return NotFound();
            }

            var amountInCents = (int)(multa.MontoMulta * 100); // Asegúrate de que "MontoMulta" es la propiedad correcta

            var domain = "http://localhost:37532"; // Cambia esto por tu dominio real
            var session = await _stripeService.CreateCheckoutSessionAsync(domain, amountInCents.ToString(), "usd");

            return Redirect(session.Url);
        }

        public IActionResult Success()
        {
            TempData["PaymentStatus"] = "Success";
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            TempData["PaymentStatus"] = "Cancel";
            return RedirectToAction("Index");
        }



    }
}

