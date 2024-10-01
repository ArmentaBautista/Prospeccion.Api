using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Prospeccion.Entidades.Negocio;

namespace Prospeccion.AccesoDatos;

public partial class ProspeccionContext : DbContext
{
    public ProspeccionContext()
    {
    }

    public ProspeccionContext(DbContextOptions<ProspeccionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EntActividad> TActividades { get; set; }

    public virtual DbSet<EntGestion> TGestiones { get; set; }

    public virtual DbSet<EntGestor> TGestores { get; set; }

    public virtual DbSet<EntPersona> TPersonas { get; set; }

    public virtual DbSet<EntResultado> TResultados { get; set; }

    public virtual DbSet<EntActividades> VActividades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntActividad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tActivid__3214EC07805C8FCE");

            entity.ToTable("tActividades");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Actividad)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.Estatus).HasDefaultValue((byte)1);
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Hora).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<EntGestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tGestion__3214EC07F866661A");

            entity.ToTable("tGestiones");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Hora).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Estatus).HasDefaultValue((byte)1);

            entity.HasOne(d => d.IdActividadNavigation).WithMany(p => p.TGestiones)
                .HasForeignKey(d => d.IdActividad)
                .HasConstraintName("FK_tGestiones_IdActividad");

            entity.HasOne(d => d.IdGestorNavigation).WithMany(p => p.TGestiones)
                .HasForeignKey(d => d.IdGestor)
                .HasConstraintName("FK_tGestiones_IdGestor");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.TGestiones)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_tGestiones_IdPersona");

            entity.HasOne(d => d.IdResultadoNavigation).WithMany(p => p.TGestiones)
                .HasForeignKey(d => d.IdResultado)
                .HasConstraintName("FK_tGestiones_IdResultado");
            
        });

        modelBuilder.Entity<EntGestor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tGestore__3214EC0795365387");

            entity.ToTable("tGestores");

            entity.Property(e => e.Estatus).HasDefaultValue((byte)1);
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Hora).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Usuario)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.TGestores)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_tGestoress_IdPersona");
        });

        modelBuilder.Entity<EntPersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tPersona__3214EC0734844A08");

            entity.ToTable("tPersonas");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Domicilio)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Estatus).HasDefaultValue((byte)1);
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Hora).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Nombre)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(130)
                .IsUnicode(false)
                .HasComputedColumnSql("(concat_ws(' ',[Nombre],[ApellidoPaterno],[ApellidoMaterno]))", false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength();
        });

        modelBuilder.Entity<EntResultado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tResulta__3214EC075399F4D0");

            entity.ToTable("tResultados");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Estatus).HasDefaultValue((byte)1);
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Hora).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Resultado)
                .HasMaxLength(24)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EntActividades>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vActividades");

            entity.Property(e => e.Actividad)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
