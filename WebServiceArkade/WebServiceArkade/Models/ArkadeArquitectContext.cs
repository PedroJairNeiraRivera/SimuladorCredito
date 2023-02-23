using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebServiceArkade.Models;

public partial class ArkadeArquitectContext : DbContext
{
    public ArkadeArquitectContext()
    {
    }

    public ArkadeArquitectContext(DbContextOptions<ArkadeArquitectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Bymax\\SQLEXPRESS;Database=ArkadeArquitect;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_usuarios");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Celular).HasColumnName("celular");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(256)
                .IsFixedLength()
                .HasColumnName("contraseña");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Sexo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sexo");
            entity.Property(e => e.TipoAsociacion)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("tipo_asociacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
