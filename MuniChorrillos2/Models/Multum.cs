using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class Multum
{
    public int IdMulta { get; set; }

    public DateTime? FecMulta { get; set; }

    public TimeSpan? HoraMulta { get; set; }

    public string? LugarMulta { get; set; }

    public string? DistritoMulta { get; set; }

    public string? NroSerie { get; set; }

    public string? Placa { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Nmotor { get; set; }

    public int? Año { get; set; }

    public string? Color { get; set; }

    public string? Estado { get; set; }

    public string? Propietario { get; set; }

    public string? Email { get; set; }

    public string? Direcion { get; set; }

    public string? Grua { get; set; }

    public int IdDeposito { get; set; }

    public int IdInfraccion { get; set; }

    public int IdPersonal { get; set; }

    public string? EstPago { get; set; }

    public string? CodPago { get; set; } 

    public int Telefono { get; set; }

    public string? Observaciones { get; set; }

    public string? ImagenBase64 { get; set; }

    public decimal MontoMulta { get; set; }

    public virtual Deposito? IdDepositoNavigation { get; set; } = null!;

    public virtual Infraccion? IdInfraccionNavigation { get; set; } = null!;

    public virtual Personal? IdPersonalNavigation { get; set; } = null!;
}
