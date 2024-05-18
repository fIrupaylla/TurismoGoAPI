using System;
using System.Collections.Generic;

namespace TurismoGoAPI.Data;

public partial class Actividades
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Ubicacion { get; set; }

    public decimal? Precio { get; set; }

    public string? Duracion { get; set; }

    public int? EmpresaId { get; set; }

    public virtual Empresas? Empresa { get; set; }

    public virtual ICollection<Resenas> Resenas { get; set; } = new List<Resenas>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
