
using ProjectZurich.Domain.Entities;

namespace ProjectZurich.Domain.Repositories
{
    public interface ISeguradoRepository
    {
        Task AddSegurado(Segurado segurado);
    }
}
