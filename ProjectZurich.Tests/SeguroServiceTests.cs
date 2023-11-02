using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectZurich.Application.Services;
using ProjectZurich.Domain.Repositories;
using ProjectZurich.Infrastructure;

namespace ProjectZurich.Tests
{
    public class SeguroServiceTests
    {        
        private readonly Mock<ISeguroRepository> seguroRepositoryMock = new Mock<ISeguroRepository>();

        [Fact]
        public void CalcularTaxaRisco_DeveRetornarTaxaRiscoCorreta()
        {
            // Arrange
            decimal valorVeiculo = 10000;
            SeguroService seguroService = new SeguroService(seguroRepositoryMock.Object);

            // Act
            decimal taxaRisco = seguroService.CalcularTaxaRisco(valorVeiculo);

            // Assert
            decimal taxaEsperada = 2.5m;
            Assert.Equal(taxaEsperada, taxaRisco, 2);
        }

        [Fact]
        public void CalcularPremioRisco_DeveRetornarPremioRiscoCorreto()
        {
            // Arrange
            decimal valorVeiculo = 10000; 
            decimal taxaRisco = 2.5m; 
            SeguroService seguroService = new SeguroService(seguroRepositoryMock.Object);

            // Act
            decimal premioRisco = seguroService.CalcularPremioRisco(valorVeiculo, taxaRisco);

            // Assert
            decimal premioEsperado = 250;
            Assert.Equal(premioEsperado, premioRisco, 2);
        }

        [Fact]
        public void CalcularPremioPuro_DeveRetornarPremioPuroCorreto()
        {
            // Arrange
            decimal valorVeiculo = 10000; 
            decimal taxaRisco = 2.5m; 
            SeguroService seguroService = new SeguroService(seguroRepositoryMock.Object);

            // Act
            decimal premioPuro = seguroService.CalcularPremioPuro(valorVeiculo, taxaRisco);

            // Assert
            decimal premioPuroEsperado = 257.5m;
            Assert.Equal(premioPuroEsperado, premioPuro, 2);
        }

        [Fact]
        public void CalcularPremioComercial_DeveRetornarPremioComercialCorreto()
        {
            // Arrange
            decimal valorVeiculo = 10000;
            SeguroService seguroService = new SeguroService(seguroRepositoryMock.Object);

            // Act
            decimal premioComercial = seguroService.CalcularPremioComercial(valorVeiculo);

            // Assert
            decimal premioComercialEsperado = 270.37m;
            Assert.Equal(premioComercialEsperado, premioComercial, 2);
        }
    }
}