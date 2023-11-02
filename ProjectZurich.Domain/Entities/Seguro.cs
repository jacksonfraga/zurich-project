using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZurich.Domain.Entities
{
    public class Seguro
    {
        public int Id { get; set; }
        public Veiculo Veiculo { get; set; }
        public Segurado Segurado { get; set; }
        public decimal PremioComercial { get; set; }
    }
}
