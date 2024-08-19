using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class Infraccion
{
    public int IdInfraccion { get; set; }

    public string? NomInfraccion { get; set; }

    public string? Descripcion { get; set; }

    public string? Resolucion { get; set; }

    public string? Rango { get; set; }

    public double? Monto { get; set; }

    public virtual ICollection<Multum> Multa { get; set; } = new List<Multum>();
}
