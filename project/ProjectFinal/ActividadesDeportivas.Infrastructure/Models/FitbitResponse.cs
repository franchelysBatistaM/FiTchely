using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadesDeportivas.Infrastructure.Models
{
    public class FitbitResponse
    {
        public DateTime Fecha { get; set; }
        public int CaloriasQuemadas { get; set; }
        public int Pasos { get; set; }
        public int MinutosSedentarios { get; set; }
    }
}