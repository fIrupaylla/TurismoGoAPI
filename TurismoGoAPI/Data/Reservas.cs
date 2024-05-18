using System;
using System.Collections.Generic;

namespace TurismoGoAPI.Data;

public partial class Reservas
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int? ActividadId { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? CantidadPersonas { get; set; }

    public virtual Actividades? Actividad { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
