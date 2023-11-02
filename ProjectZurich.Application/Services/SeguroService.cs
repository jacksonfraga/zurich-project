using Microsoft.EntityFrameworkCore;
using ProjectZurich.Domain.Entities;
using ProjectZurich.Domain.Repositories;
using ProjectZurich.Domain.Services;
using ProjectZurich.Infrastructure;

namespace ProjectZurich.Application.Services
{
    public class SeguroService : ISeguroService
    {
        private const decimal MARGEM_SEGURANCA = 3m;
        private const decimal LUCRO = 5m;
        private readonly ISeguroRepository _seguroRepository;

        public SeguroService(ISeguroRepository seguroRepository)
        {
            _seguroRepository = seguroRepository;
        }

        public decimal CalcularTaxaRisco(decimal valorVeiculo)
        {
            return (valorVeiculo * 5) / (2 * valorVeiculo);
        }

        public decimal CalcularPremioRisco(decimal valorVeiculo, decimal taxaRisco)
        {
            return (taxaRisco / 100) * valorVeiculo;
        }

        public decimal CalcularPremioPuro(decimal valorVeiculo, decimal taxaRisco)
        {
            decimal premioRisco = CalcularPremioRisco(valorVeiculo, taxaRisco);
            return premioRisco * (1 + (MARGEM_SEGURANCA / 100));
        }

        public decimal CalcularPremioComercial(decimal valorVeiculo)
        {
            decimal taxaRisco = CalcularTaxaRisco(valorVeiculo);
            decimal premioPuro = CalcularPremioPuro(valorVeiculo, taxaRisco);
            decimal premioComercial = (1 + (LUCRO / 100)) * premioPuro;
            return Math.Truncate(100 * premioComercial) / 100;
        }

        public async Task<Seguro?> RetornarDadosSeguroAsync(int id)
        {
            return await _seguroRepository.GetSeguroByIdAsync(id);
        }

        public async Task SalvarSeguroAsync(Seguro seguro)
        {
            await _seguroRepository.AddSeguroAsync(seguro);
        }

        public Task<decimal> CalcularMediaPremioComercialAsync()
        {
            return _seguroRepository.CalcularMediaPremioComercialAsync();
        }
    }
}
