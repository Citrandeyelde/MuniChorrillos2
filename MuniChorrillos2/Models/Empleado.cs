using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? NomEmpleado { get; set; }

    public string? ApellidoP { get; set; }

    public string? ApellidoM { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public byte? Activo { get; set; }

    public string? EstadoCivil { get; set; }

    public int? NroIdentidad { get; set; }

    public int IdTipoDoc { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual TipoDoc? IdTipoDocNavigation { get; set; } = null!;

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
