using ProjectZurich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZurich.Domain.DTO
{
    public class DadosCalculoSeguro
    {
        public Veiculo Veiculo { get; set; }
        public Segurado Segurado { get; set; }
    }
}
