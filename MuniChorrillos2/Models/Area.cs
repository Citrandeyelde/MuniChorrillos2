using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class Area
{
    public int IdArea { get; set; }

    public string? NomArea { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
