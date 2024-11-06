using Microsoft.EntityFrameworkCore;
using SalesManagementApp.Models;  // Asegúrate de usar el namespace correcto

namespace SalesManagementApp.Data  // Cambio a SalesManagementApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Definimos las propiedades DbSet que representan las tablas de la base de datos
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<DetalleVenta> Detalle { get; set; }

        // Sobreescribimos ciertas convenciones predeterminadas de Entity Framework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Llamar a la implementación de la clase base

            // Configuramos la precisión de los valores decimales
            modelBuilder.Entity<Producto>()
                .Property(d => d.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Venta>()
               .Property(d => d.Total)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DetalleVenta>()
               .Property(d => d.Subtotal)  // Usamos Subtotal correctamente
               .HasColumnType("decimal(18,2)");
        }
    }
}
