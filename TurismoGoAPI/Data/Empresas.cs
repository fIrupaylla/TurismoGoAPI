using System;
using System.Collections.Generic;

namespace TurismoGoAPI.Data;

public partial class Empresas
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Actividades> Actividades { get; set; } = new List<Actividades>();
}
