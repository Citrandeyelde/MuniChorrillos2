using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class Deposito
{
    public int IdDeposito { get; set; }

    public string? NomDeposito { get; set; }

    public string? Direccion { get; set; }

    public int IdPersonal { get; set; }

    public virtual Personal? IdPersonalNavigation { get; set; } = null!;

    public virtual ICollection<Multum> Multa { get; set; } = new List<Multum>();
}
