using ActividadesDeportivas.Domain.Core;

namespace ActividadesDeportivas.Domain.Entities
{
    public class UsuarioDeportivo : ClaseBase
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;

        public int Edad { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }

        public ICollection<ActividadFisica> Actividades { get; set; } = new List<ActividadFisica>();
        public ICollection<EstadisticaProgreso> EstadisticasProgreso { get; set; } = new List<EstadisticaProgreso>();
        public ICollection<ResumenDiarioFitbit> ResumenesDiarios { get; set; } = new List<ResumenDiarioFitbit>();
    }
}
