using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class CabComprobante
{
    public int IdCabeceraC { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeSpan? Hora { get; set; }

    public int Tcomprobante { get; set; }

    public string? MedioPago { get; set; }

    public string? Entidad { get; set; }

    public virtual ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
}
