using System;
using System.Collections.Generic;

namespace TurismoGoAPI.Data;

public partial class Usuarios
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Contrasena { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Resenas> Resenas { get; set; } = new List<Resenas>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
