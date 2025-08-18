using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadesDeportivas.Application.Dtos;

namespace ActividadesDeportivas.Application.Dtos.ActividadFisica
{
    public class ActividadFisicaDto : DtoBase
    {
        public int UsuarioDeportivoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; 
        public DateTime Fecha { get; set; }
        public int DuracionMinutos { get; set; }
        public float CaloriasQuemadas { get; set; }
        public string? Notas { get; set; }
    }
}
