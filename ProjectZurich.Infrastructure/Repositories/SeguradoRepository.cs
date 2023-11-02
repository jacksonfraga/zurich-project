
using ProjectZurich.Domain.Entities;
using ProjectZurich.Domain.Repositories;

namespace ProjectZurich.Infrastructure.Repositories
{
    public class SeguradoRepository : ISeguradoRepository
    {
        private readonly ApplicationDbContext _context;

        public SeguradoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSegurado(Segurado segurado)
        {
            _context.Segurados.Add(segurado);
            await _context.SaveChangesAsync();
        }
    }
}
