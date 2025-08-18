using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadesDeportivas.Application.Dtos;

namespace ActividadesDeportivas.Application.Dtos.ProgresoEstadistica
{
    public class ProgresoEstadisticaDto : DtoBase
    {
        public int UsuarioDeportivoId { get; set; }
        public DateTime Fecha { get; set; }
        public float Peso { get; set; }
        public float IMC { get; set; }
        public float GrasaCorporal { get; set; }
    }
}
