using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TurismoGoAPI.Data;
//Este es un cambio

public partial class TurismoGoContext : DbContext
{
    public TurismoGoContext()
    {
    }

    public TurismoGoContext(DbContextOptions<TurismoGoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividades> Actividades { get; set; }

    public virtual DbSet<Empresas> Empresas { get; set; }

    public virtual DbSet<Resenas> Resenas { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=localhost;Database=TurismoGo;User=sa;Pwd=123456789;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividades>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activida__3214EC2798F3A094");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Duracion).HasMaxLength(50);
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Ubicacion).HasMaxLength(100);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Actividades)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Actividad__Empre__3B75D760");
        });

        modelBuilder.Entity<Empresas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresas__3214EC27317E54B4");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Resenas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resenas__3214EC27EBF10AC1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActividadId).HasColumnName("ActividadID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Actividad).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.ActividadId)
                .HasConstraintName("FK__Resenas__Activid__4316F928");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Resenas__Usuario__4222D4EF");
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservas__3214EC275BD50ED3");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActividadId).HasColumnName("ActividadID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Actividad).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ActividadId)
                .HasConstraintName("FK__Reservas__Activi__3F466844");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Reservas__Usuari__3E52440B");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC276C62D8B4");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contrasena).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
