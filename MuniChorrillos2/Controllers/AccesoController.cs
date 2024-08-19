using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MuniChorrillos2.Models;
using System.Data;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MuniChorrillos2.Controllers
{
    
    public class AccesoController : Controller
    {
        static string cadena = "Data Source=localhost;Initial Catalog=BDMULTAS2;Integrated Security=True;TrustServerCertificate=true;";
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioAcceso oUsuarioAcceso)
        {
            oUsuarioAcceso.Contraseña = ConvertirSha256(oUsuarioAcceso.Contraseña);

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("Sp_ValPersonal", cn);
                cmd.Parameters.AddWithValue("UsuarioAcceso", oUsuarioAcceso.UsuarioNom);
                cmd.Parameters.AddWithValue("Contraseña", oUsuarioAcceso.Contraseña);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                oUsuarioAcceso.IdPersonal = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                if (oUsuarioAcceso.IdPersonal != 0)
                {
                    List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, oUsuarioAcceso.UsuarioNom)
            };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = false,
                    };
                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), properties);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["MensajeError"] = "Usuario o contraseña incorrectos.";
                    return View();
                }
            }
        }


        public async Task<IActionResult> Salir() {
            
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        
        }

        

       
    }
}
