using Microsoft.EntityFrameworkCore;
using TurnosSaas.Models;

namespace TurnosSaas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; }=null!;
        public DbSet<Detalle_Turno> Detalle_Turnos { get; set; } = null!;
        public DbSet<Direccion> Direcciones { get; set; } = null!;
        //public DbSet<ErrorViewModel> ErrorViewModels { get; set; } = null!;
        public DbSet<Turno> Turnos { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Rol> Roles { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Turnos)
                .WithOne(t => t.Usuario)
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Producto>()
                .HasMany(p => p.DetallesTurno)
                .WithOne(dt => dt.Producto)
                .HasForeignKey(dt => dt.ProductoId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Turno>()
                .HasMany(t => t.DetallesTurno)
                .WithOne(dt => dt.Turno)
                .HasForeignKey(dt => dt.TurnoId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Turno>()
                .Ignore(d => d.Direccion);
            modelBuilder.Entity<Categoria>()
                .HasMany(p => p.Productos)
                .WithOne(c => c.Categoria)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
