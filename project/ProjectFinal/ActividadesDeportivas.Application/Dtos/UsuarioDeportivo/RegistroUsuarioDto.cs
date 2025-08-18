using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadesDeportivas.Application.Dtos.UsuarioDeportivo
{
    public class RegistroUsuarioDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Edad { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
    }
}
