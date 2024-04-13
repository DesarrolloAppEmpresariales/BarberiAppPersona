using BarberiApp.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberiApp.WebApi.Models
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}