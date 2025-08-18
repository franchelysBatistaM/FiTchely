using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadesDeportivas.Application.Dtos.ActividadFisica
{
    public class ActividadFisicaDetalleDto : ActividadFisicaDto
    {
        public string UsuarioNombre { get; set; } = string.Empty;
        public string UsuarioApellido { get; set; } = string.Empty;
    }
}
