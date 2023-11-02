using ProjectZurich.Domain.Entities;
using ProjectZurich.Domain.Repositories;

namespace ProjectZurich.Infrastructure.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly ApplicationDbContext _context;

        public VeiculoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
        }
    }
}
