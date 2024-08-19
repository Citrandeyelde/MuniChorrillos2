using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuniChorrillos2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MuniChorrillos2.Controllers
{
    public class UsuariosClientesController : Controller
    {
        private readonly Bdmultas2Context _context;

        public UsuariosClientesController(Bdmultas2Context context)
        {
            _context = context;
        }

        // GET: UsuariosClientes
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return View(usuarios);
        }

        // GET: UsuariosClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: UsuariosClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuariosClientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,NombreU,ApellidoU,Direccion,Telefono,Email,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Usuario creado con éxito.";
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // POST: UsuariosClientes/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate([Bind("IdUsuario,NombreU,ApellidoU,Direccion,Telefono,Email,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.IdUsuario == 0)
                {
                    _context.Add(usuario);
                }
                else
                {
                    _context.Update(usuario);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(usuario.IdUsuario == 0 ? "Create" : "Edit", usuario);
        }


        // GET: UsuariosClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: UsuariosClientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,NombreU,ApellidoU,Direccion,Telefono,Email,Contraseña")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Usuario actualizado con éxito.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            return View(usuario);
        }

        // GET: UsuariosClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: UsuariosClientes/DeleteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Usuario eliminado con éxito.";
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}
