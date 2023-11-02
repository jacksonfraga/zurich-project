using ProjectZurich.Domain.Entities;

namespace ProjectZurich.Domain.Services
{
    public interface ISeguroService
    {
        decimal CalcularPremioComercial(decimal valorVeiculo);
        decimal CalcularPremioPuro(decimal valorVeiculo, decimal taxaRisco);
        decimal CalcularPremioRisco(decimal valorVeiculo, decimal taxaRisco);
        decimal CalcularTaxaRisco(decimal valorVeiculo);
        Task<Seguro?> RetornarDadosSeguroAsync(int id);
        Task SalvarSeguroAsync(Seguro seguro);
        Task<decimal> CalcularMediaPremioComercialAsync();
    }
}