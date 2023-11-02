using Microsoft.EntityFrameworkCore;
using ProjectZurich.Domain.Entities;
using ProjectZurich.Domain.Repositories;

namespace ProjectZurich.Infrastructure.Repositories
{
    public class SeguroRepository : ISeguroRepository
    {
        private readonly ApplicationDbContext _context;

        public SeguroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSeguroAsync(Seguro seguro)
        {
            _context.Seguros.Add(seguro);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> CalcularMediaPremioComercialAsync()
        {
            return await _context.Seguros.AverageAsync(s => s.PremioComercial);
        }

        public async Task<Seguro?> GetSeguroByIdAsync(int id)
        {
            var retorno = await _context.Seguros
                .Where(x => x.Id == id)
                .Include(s => s.Veiculo)
                .Include(s => s.Segurado)
                .ToListAsync();

            return retorno.FirstOrDefault();
        }
    }
}
