using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class Personal
{
    public int IdPersonal { get; set; }

    public int IdEmpleado { get; set; }

    public int IdArea { get; set; }

    public string? UsuarioAcceso { get; set; } = null;

    public string? Contraseña { get; set; } = null!;

    public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();

    public virtual Area? IdAreaNavigation { get; set; } = null!;

    public virtual Empleado? IdEmpleadoNavigation { get; set; } = null!;

    public virtual ICollection<Multum> Multa { get; set; } = new List<Multum>();

    public virtual ICollection<Vmunicipal> Vmunicipals { get; set; } = new List<Vmunicipal>();
}
