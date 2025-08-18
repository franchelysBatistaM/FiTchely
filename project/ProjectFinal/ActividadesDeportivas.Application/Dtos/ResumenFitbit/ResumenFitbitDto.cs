using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadesDeportivas.Application.Dtos;

namespace ActividadesDeportivas.Application.Dtos.ResumenFitbit
{
    public class ResumenFitbitDto : DtoBase
    {
        public int UsuarioDeportivoId { get; set; }
        public DateTime Fecha { get; set; }
        public int CaloriasQuemadas { get; set; }
        public int Pasos { get; set; }
        public int MinutosSedentarios { get; set; }
    }
}
