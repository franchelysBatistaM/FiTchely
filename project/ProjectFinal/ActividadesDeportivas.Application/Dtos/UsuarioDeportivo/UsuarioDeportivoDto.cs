using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadesDeportivas.Application.Dtos;

namespace ActividadesDeportivas.Application.Dtos.UsuarioDeportivo
{
    public class UsuarioDeportivoDto : DtoBase
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Edad { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
    }
}
