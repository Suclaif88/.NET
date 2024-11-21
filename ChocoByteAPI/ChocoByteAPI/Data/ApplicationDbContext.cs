using ChocoByteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChocoByteAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define las tablas (DBSet) que usarás en la base de datos
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

