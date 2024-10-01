using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Prospeccion.Entidades.Seguridad;

namespace Prospeccion.AccesoDatos;

public partial class SeguridadDbContext : DbContext
{
    public SeguridadDbContext()
    {
    }

    public SeguridadDbContext(DbContextOptions<SeguridadDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colaborador> Colaboradors { get; set; }

    public virtual DbSet<Colaboradorusuario> Colaboradorusuarios { get; set; }

    public virtual DbSet<Colaboradorusuariopermiso> Colaboradorusuariopermisos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Colaborador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("colaborador_pkey");

            entity.ToTable("colaborador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.Correoelectronico)
                .HasMaxLength(100)
                .HasColumnName("correoelectronico");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechacreacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idpuesto).HasColumnName("idpuesto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuariocreacion)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuariocreacion");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdpuestoNavigation).WithMany(p => p.Colaboradors)
                .HasForeignKey(d => d.Idpuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaborador_puesto");
        });

        modelBuilder.Entity<Colaboradorusuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("colaboradorusuario_pkey");

            entity.ToTable("colaboradorusuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bloqueadohasta)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("bloqueadohasta");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("clave");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechacreacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idcolaborador).HasColumnName("idcolaborador");
            entity.Property(e => e.Intentosfallidos).HasColumnName("intentosfallidos");
            entity.Property(e => e.Ultimobloqueo)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ultimobloqueo");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .HasColumnName("usuario");
            entity.Property(e => e.Usuariocreacion)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuariocreacion");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdcolaboradorNavigation).WithMany(p => p.Colaboradorusuarios)
                .HasForeignKey(d => d.Idcolaborador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaboradorusuario_colaborador");
        });

        modelBuilder.Entity<Colaboradorusuariopermiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("colaboradorusuariopermiso_pkey");

            entity.ToTable("colaboradorusuariopermiso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechacreacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idcolaboradorusuario).HasColumnName("idcolaboradorusuario");
            entity.Property(e => e.Idpermiso).HasColumnName("idpermiso");
            entity.Property(e => e.Usuariocreacion)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuariocreacion");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdcolaboradorusuarioNavigation).WithMany(p => p.Colaboradorusuariopermisos)
                .HasForeignKey(d => d.Idcolaboradorusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaboradorusuariopermiso_colaboradorusuario");

            entity.HasOne(d => d.IdpermisoNavigation).WithMany(p => p.Colaboradorusuariopermisos)
                .HasForeignKey(d => d.Idpermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaboradorusuariopermiso_permiso");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permiso_pkey");

            entity.ToTable("permiso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechacreacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuariocreacion)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuariocreacion");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("puesto_pkey");

            entity.ToTable("puesto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechacreacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuariocreacion)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuariocreacion");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
