using System;
using System.Collections.Generic;

namespace MuniChorrillos2.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public int IdEmpleado { get; set; }

    public int IdArea { get; set; }

    public string? Dia { get; set; }

    public TimeSpan? Hingreso { get; set; }

    public TimeSpan? Hsalida { get; set; }

    public virtual Area IdAreaNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
