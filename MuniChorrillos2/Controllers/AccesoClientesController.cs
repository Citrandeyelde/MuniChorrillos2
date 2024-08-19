using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MuniChorrillos2.Models;

namespace MuniChorrillos2.Controllers
{
    public class AccesoClientesController : Controller
    {
        private readonly Bdmultas2Context _context;

        public AccesoClientesController(Bdmultas2Context context)
        {
            _context = context;
        }

        public IActionResult LoginCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginCliente(Usuario userModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == userModel.Email && u.Contraseña == userModel.Contraseña);

                if (usuario != null)
                {
                    // Guardar el email en la sesión o en el objeto User
                    HttpContext.Session.SetString("UserEmail", userModel.Email); // Usando sesión
                    // Aquí debes implementar la lógica para iniciar sesión
                    return RedirectToAction("Index", "PagarMulta"); // Cambia "Home" por el controlador de destino
                }
                else
                {
                    // Usuario no encontrado o contraseña incorrecta
                    ModelState.AddModelError("", "El email o la contraseña son incorrectos.");
                }
            }
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Agrega el usuario a la base de datos
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                // Aquí puedes agregar un mensaje de éxito para que se muestre en la vista
                TempData["SuccessMessage"] = "Usuario registrado con éxito.";

                // Redirecciona a la vista de login después del registro
                return RedirectToAction("LoginCliente");
            }

            // Si hay errores en el modelo, vuelve a mostrar el modal con los errores
            return View("LoginCliente", usuario);
        }


    }
}
