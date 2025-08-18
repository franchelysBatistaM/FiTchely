using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadesDeportivas.Application.Dtos.ProgresoEstadistica
{
    public class RegistrarProgresoDto
    {
        public DateTime Fecha { get; set; }
        public float Peso { get; set; }
        public float IMC { get; set; }
        public float GrasaCorporal { get; set; }
    }
}
