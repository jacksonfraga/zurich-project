using Microsoft.AspNetCore.Mvc;
using ProjectZurich.Domain.DTO;
using ProjectZurich.Domain.Entities;
using ProjectZurich.Domain.Services;

namespace ProjectZurich.API.Controllers
{
    [Route("api/[controller]")]
    public class SeguroController : Controller
    {
        private readonly ISeguroService _seguroService;        

        public SeguroController(ISeguroService seguroService)
        {
            _seguroService = seguroService;
        }

        [HttpGet]
        public ActionResult<decimal> CalcularSeguro(decimal valorVeiculo)
        {
            decimal premioComercial = _seguroService.CalcularPremioComercial(valorVeiculo);
            return Ok(premioComercial);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarDadosSeguroAsync(int id)
        {
            var seguro = await _seguroService.RetornarDadosSeguroAsync(id);

            if (seguro == null)
            {
                return NotFound();
            }

            return Ok(seguro);
        }

        [HttpPost("insurance-quote")]
        public async Task<IActionResult> CalcularSeguro([FromBody] DadosCalculoSeguro dadosCalculo)
        {
            if (dadosCalculo == null)
            {
                return BadRequest();
            }
                        
            decimal premioComercial = _seguroService.CalcularPremioComercial(dadosCalculo.Veiculo.ValorVeiculo);

            
            var novoSeguro = new Seguro
            {
                Veiculo = dadosCalculo.Veiculo,
                Segurado = dadosCalculo.Segurado,
                PremioComercial = premioComercial
            };

            await _seguroService.SalvarSeguroAsync(novoSeguro);

            return Ok(premioComercial);
        }

        [HttpGet("report-average")]
        public async Task<IActionResult> CalcularMediaPremioComercialAsync()
        {
            decimal media = await _seguroService.CalcularMediaPremioComercialAsync();
            var resultado = new { MediaPremioComercial = media };
            return Ok(resultado);
        }
    }
}
