using System;
using System.Collections.Generic;

namespace TurismoGoAPI.Data;

public partial class Resenas
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int? ActividadId { get; set; }

    public string? Comentario { get; set; }

    public int? Valoracion { get; set; }

    public virtual Actividades? Actividad { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
