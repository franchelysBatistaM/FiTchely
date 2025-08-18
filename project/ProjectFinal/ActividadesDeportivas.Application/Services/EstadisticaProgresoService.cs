using ActividadesDeportivas.Application.Contracts;
using ActividadesDeportivas.Application.Dtos.ProgresoEstadistica;
using ActividadesDeportivas.Domain.Entities;
using ActividadesDeportivas.Infrastructure.Interfaces;

namespace ActividadesDeportivas.Application.Services
{
    public class EstadisticaProgresoService : IEstadisticaProgresoService
    {
        private readonly IEstadisticaProgresoRepository _progresoRepo;

        public EstadisticaProgresoService(IEstadisticaProgresoRepository progresoRepo)
        {
            _progresoRepo = progresoRepo;
        }

        public async Task<List<ProgresoEstadisticaDto>> GetProgresoByUsuarioIdAsync(int usuarioId)
        {
            var progresos = await _progresoRepo.GetByUsuarioAsync(usuarioId);

            return progresos
                .Where(p => p.Activo)
                .OrderByDescending(p => p.Fecha)
                .Select(p => new ProgresoEstadisticaDto
                {
                    Id = p.Id,
                    UsuarioDeportivoId = p.UsuarioDeportivoId,
                    Fecha = p.Fecha,
                    Peso = p.Peso,
                    IMC = p.IMC,
                    GrasaCorporal = p.GrasaCorporal,
                    FechaCreacion = p.FechaCreacion,
                    FechaModificacion = p.FechaModificacion,
                    Activo = p.Activo
                }).ToList();
        }

        public async Task<ProgresoEstadisticaDto?> RegistrarProgresoAsync(RegistrarProgresoDto progresoDto, int usuarioId)
        {
            var progreso = new EstadisticaProgreso
            {
                UsuarioDeportivoId = usuarioId,
                Fecha = progresoDto.Fecha,
                Peso = progresoDto.Peso,
                IMC = progresoDto.IMC,
                GrasaCorporal = progresoDto.GrasaCorporal,
                FechaCreacion = DateTime.UtcNow,
                Activo = true
            };

            await _progresoRepo.AddAsync(progreso);

            return new ProgresoEstadisticaDto
            {
                Id = progreso.Id,
                UsuarioDeportivoId = progreso.UsuarioDeportivoId,
                Fecha = progreso.Fecha,
                Peso = progreso.Peso,
                IMC = progreso.IMC,
                GrasaCorporal = progreso.GrasaCorporal,
                FechaCreacion = progreso.FechaCreacion,
                Activo = progreso.Activo
            };
        }
    }
}
