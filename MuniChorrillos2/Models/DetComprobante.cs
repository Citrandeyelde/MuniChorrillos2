using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class DetComprobante
{
    public int IdDetalleC { get; set; }

    public double? Subtotal { get; set; }

    public double? Total { get; set; }

    public double? Vuelto { get; set; }

    public virtual ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
}
