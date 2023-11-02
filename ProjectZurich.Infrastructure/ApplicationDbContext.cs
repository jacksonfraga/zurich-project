using Microsoft.EntityFrameworkCore;
using ProjectZurich.Domain.Entities;

namespace ProjectZurich.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Segurado> Segurados { get; set; }
        public DbSet<Seguro> Seguros { get; set; }
    }
}
