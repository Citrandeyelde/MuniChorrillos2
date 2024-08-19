using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreU { get; set; }

    public string? ApellidoU { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Contraseña { get; set; }
}
