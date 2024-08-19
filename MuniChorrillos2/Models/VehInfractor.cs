using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class VehInfractor
{
    public int IdVehInfractor { get; set; }

    public string? Placa { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Nmotor { get; set; }

    public int? Año { get; set; }

    public string? Color { get; set; }

    public string? Estado { get; set; }
}
