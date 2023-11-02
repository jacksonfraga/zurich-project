using ProjectZurich.Domain.Entities;

namespace ProjectZurich.Domain.Repositories
{
    public interface IVeiculoRepository
    {
        Task AddVeiculo(Veiculo veiculo);
    }
}
