using BarberiAppPersona.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberiAppPersona.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado>? Empleado { get; set; }
        public virtual DbSet<Cliente>? Cliente { get; set; }
        public virtual DbSet<AdminNeg>? AdminNeg { get; set; }
        public virtual DbSet<AdminPlat>? AdminPlat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleado");
                entity.Property(e => e.EmpleadoID).HasColumnName("Id");
                entity.Property(e => e.Genero).HasMaxLength(1).IsUnicode(false);
                entity.Property(e => e.Cedula).HasMaxLength(10).IsUnicode(false);                
                entity.Property(e => e.Nombre).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.UsuarioID).HasColumnName("usuario_id").HasMaxLength(5).IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.Property(e => e.ClienteID).HasColumnName("Id");
                entity.Property(e => e.Genero).HasMaxLength(1).IsUnicode(false);
                entity.Property(e => e.Cedula).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.Nombre).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.UsuarioID).HasColumnName("usuario_id").HasMaxLength(5).IsUnicode(false);
            });

            modelBuilder.Entity<AdminNeg>(entity =>
            {
                entity.ToTable("Admin_neg");
                entity.Property(e => e.AdminNegID).HasColumnName("Id");
                entity.Property(e => e.Genero).HasMaxLength(1).IsUnicode(false);
                entity.Property(e => e.Cedula).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.Nombre).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.UsuarioID).HasColumnName("usuario_id").HasMaxLength(5).IsUnicode(false);
            });

            modelBuilder.Entity<AdminPlat>(entity =>
            {
                entity.ToTable("Admin_plat");
                entity.Property(e => e.AdminPlatID).HasColumnName("Id");
                entity.Property(e => e.Genero).HasMaxLength(1).IsUnicode(false);
                entity.Property(e => e.Cedula).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.Nombre).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.UsuarioID).HasColumnName("usuario_id").HasMaxLength(5).IsUnicode(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}