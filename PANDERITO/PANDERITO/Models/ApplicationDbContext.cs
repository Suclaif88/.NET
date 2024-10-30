using Microsoft.EntityFrameworkCore;
using PANDERITO.Models;

namespace PANDERITO.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
