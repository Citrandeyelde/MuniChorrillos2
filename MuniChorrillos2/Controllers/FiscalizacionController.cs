using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuniChorrillos2.Models;
using MuniChorrillos2.Servicios;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;





namespace MuniChorrillos2.Controllers
{
    public class FiscalizacionController : Controller
    {
        private readonly Bdmultas2Context _context;
        private readonly IEmailServices _emailServices;


        private string GenerateCodPago()
        {
            return "CP" + DateTime.Now.Ticks.ToString().Substring(0, 10); // Ajusta la longitud si es necesario
        }


        public FiscalizacionController(Bdmultas2Context context , IEmailServices emailServices)
        {
            _context = context;
            _emailServices = emailServices; 
        }

        private string GenerateNroSerie()
        {
            // Recorta el valor para que tenga una longitud adecuada
            return "MUL" + DateTime.Now.Ticks.ToString().Substring(0, 10); // Ajusta la longitud según sea necesario
        }

        // GET: Fiscalizacion/Index
        public async Task<IActionResult> Index()
        {
            // Generar automáticamente los valores para NroSerie, FecMulta y HoraMulta
            var multum = new Multum
            {
                NroSerie = GenerateNroSerie(),
                FecMulta = DateTime.Now.Date,
                HoraMulta = DateTime.Now.TimeOfDay,
                CodPago = GenerateCodPago()
            };



            ViewData["IdDeposito"] = new SelectList(await _context.Depositos.ToListAsync(), "IdDeposito", "NomDeposito");
            ViewData["IdPersonal"] = new SelectList(await _context.Personals.ToListAsync(), "IdPersonal", "UsuarioAcceso");
            ViewData["IdVehiculoMunicipal"] = new SelectList(await _context.Vmunicipals.ToListAsync(), "IdVehiculoMunicipal", "Placa");

            // Obtener las infracciones con su monto
            var infracciones = await _context.Infraccions
                .Select(i => new
                {
                    i.IdInfraccion,
                    i.NomInfraccion,
                    i.Descripcion,
                    MontoCalculado = i.Monto * 5050, // Calcular el monto en base a la UIT
                    EstPago = "N P"  // Asignar el estado de pago por defecto
                })
                .ToListAsync();

            // Pasar las infracciones a la vista usando ViewData
            ViewData["IdInfraccion"] = infracciones.Select(i => new
            {
                i.IdInfraccion,
                i.NomInfraccion,
                i.Descripcion,
                i.MontoCalculado
            }).ToList();

            return View(multum);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("IdMulta,FecMulta,HoraMulta,LugarMulta,DistritoMulta,NroSerie,Placa,Marca,Modelo,Nmotor,Año,Color,Estado,Propietario,Telefono,Email,Direcion,Grua,IdDeposito,IdInfraccion,IdPersonal,EstPago,CodPago,Observaciones,ImagenBase64,MontoMulta")] Multum multum)
        {
            if (ModelState.IsValid)
            {
                var oEmailDto = new EmailDTO();

                oEmailDto.Para = multum.Email.ToString();
                oEmailDto.Asunto = "Paga tu multa INFRACTORRRR";
                oEmailDto.Contenido = "Has tenido una multa acercate a pagar";
                _emailServices.SendEmail(oEmailDto);
                // Establecer el estado de pago a "no pagado"
                multum.EstPago = "N P";

                // Asignar la imagen base64 capturada
                multum.ImagenBase64 = multum.ImagenBase64;

                // Guardar los datos
                _context.Add(multum);
                await _context.SaveChangesAsync();

                // Establecer mensaje de confirmación
                TempData["SuccessMessage"] = "La multa se ha generado exitosamente.";

                return RedirectToAction(nameof(Index));
            }

            // Si la validación falla, recargar las listas desplegables
            ViewData["IdPersonal"] = new SelectList(await _context.Personals.ToListAsync(), "IdPersonal", "UsuarioAcceso", multum.IdPersonal);
            ViewData["IdDeposito"] = new SelectList(await _context.Depositos.ToListAsync(), "IdDeposito", "NomDeposito", multum.IdDeposito);
            ViewData["IdVehiculoMunicipal"] = new SelectList(await _context.Vmunicipals.ToListAsync(), "IdVehiculoMunicipal", "Placa", multum.Grua);
            ViewData["IdInfraccion"] = new SelectList(await _context.Infraccions.ToListAsync(), "IdInfraccion", "NomInfraccion", multum.IdInfraccion);
            return View(multum);
        }


    }
}
