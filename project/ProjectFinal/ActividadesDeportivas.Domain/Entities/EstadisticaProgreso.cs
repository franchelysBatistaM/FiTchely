using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadesDeportivas.Domain.Core;

namespace ActividadesDeportivas.Domain.Entities
{
    public class EstadisticaProgreso : ClaseBase
    {
        public int UsuarioDeportivoId { get; set; }
        public UsuarioDeportivo UsuarioDeportivo { get; set; } = null!;

        public DateTime Fecha { get; set; }
        public float Peso { get; set; }
        public float IMC { get; set; }
        public float GrasaCorporal { get; set; }
    }
}
