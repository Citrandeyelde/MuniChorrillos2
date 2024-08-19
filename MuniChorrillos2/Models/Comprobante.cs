using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class Comprobante
{
    public int IdComprobante { get; set; }

    public int IdCabeceraC { get; set; }

    public int IdDetalleC { get; set; }

    public int IdMulta { get; set; }

    public virtual CabComprobante IdCabeceraCNavigation { get; set; } = null!;

    public virtual DetComprobante IdDetalleCNavigation { get; set; } = null!;
}
