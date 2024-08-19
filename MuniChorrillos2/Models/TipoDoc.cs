using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class TipoDoc
{
    public int IdTipoDoc { get; set; }

    public string? Descripcion { get; set; }

    public string? NumIdentifica { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
