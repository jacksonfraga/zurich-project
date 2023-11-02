using ProjectZurich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZurich.Domain.Repositories
{
    public interface ISeguroRepository
    {
        Task AddSeguroAsync(Seguro seguro);
        Task<decimal> CalcularMediaPremioComercialAsync();
        Task<Seguro?> GetSeguroByIdAsync(int id);
    }
}
