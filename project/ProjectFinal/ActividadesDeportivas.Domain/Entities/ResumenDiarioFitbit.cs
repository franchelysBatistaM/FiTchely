using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadesDeportivas.Domain.Core;

namespace ActividadesDeportivas.Domain.Entities
{
    public class ResumenDiarioFitbit : ClaseBase
    {
        public int UsuarioDeportivoId { get; set; }
        public DateTime Fecha { get; set; }
        public int CaloriasQuemadas { get; set; }
        public int Pasos { get; set; }
        public int MinutosSedentarios { get; set; }

        public UsuarioDeportivo UsuarioDeportivo { get; set; } = null!;
    }

}
