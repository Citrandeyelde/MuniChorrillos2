using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class Vmunicipal
{
    public int IdVehiculoMunicipal { get; set; }

    public string? Placa { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Nmotor { get; set; }

    public int? Año { get; set; }

    public string? Color { get; set; }

    public string? Estado { get; set; }

    public int IdPersonal { get; set; }

    public virtual Personal? IdPersonalNavigation { get; set; } = null!;
}
