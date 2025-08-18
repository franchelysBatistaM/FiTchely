using ActividadesDeportivas.Application.Contracts;
using ActividadesDeportivas.Application.Dtos.ActividadFisica;
using ActividadesDeportivas.Domain.Entities;
using ActividadesDeportivas.Infrastructure.Interfaces;

namespace ActividadesDeportivas.Application.Services
{
    public class ActividadFisicaService : IActividadFisicaService
    {
        private readonly IActividadRepository _actividadRepo;

        public ActividadFisicaService(IActividadRepository actividadRepo)
        {
            _actividadRepo = actividadRepo;
        }

        public async Task<ActividadFisicaDto?> CrearActividadAsync(CrearActividadFisicaDto actividadDto, int usuarioId)
        {
            var actividad = new ActividadFisica
            {
                UsuarioDeportivoId = usuarioId,
                Nombre = actividadDto.Nombre,
                Tipo = actividadDto.Tipo,
                Fecha = actividadDto.Fecha,
                DuracionMinutos = actividadDto.DuracionMinutos,
                CaloriasQuemadas = actividadDto.CaloriasQuemadas,
                Notas = actividadDto.Notas,
                FechaCreacion = DateTime.UtcNow,
                Activo = true
            };

            await _actividadRepo.AddAsync(actividad);

            return new ActividadFisicaDto
            {
                Id = actividad.Id,
                UsuarioDeportivoId = actividad.UsuarioDeportivoId,
                Nombre = actividad.Nombre,
                Tipo = actividad.Tipo,
                Fecha = actividad.Fecha,
                DuracionMinutos = actividad.DuracionMinutos,
                CaloriasQuemadas = actividad.CaloriasQuemadas,
                Notas = actividad.Notas,
                FechaCreacion = actividad.FechaCreacion,
                Activo = actividad.Activo
            };
        }

        public async Task<List<ActividadFisicaDto>> ObtenerPorUsuarioAsync(int usuarioId)
        {
            var actividades = await _actividadRepo.GetByUsuarioAsync(usuarioId);

            return actividades
                .Where(a => a.Activo)
                .Select(a => new ActividadFisicaDto
                {
                    Id = a.Id,
                    UsuarioDeportivoId = a.UsuarioDeportivoId,
                    Nombre = a.Nombre,
                    Tipo = a.Tipo,
                    Fecha = a.Fecha,
                    DuracionMinutos = a.DuracionMinutos,
                    CaloriasQuemadas = a.CaloriasQuemadas,
                    Notas = a.Notas,
                    FechaCreacion = a.FechaCreacion,
                    Activo = a.Activo
                }).ToList();
        }

        public async Task<bool> ActualizarActividadAsync(int id, ActualizarActividadFisicaDto actividadDto)
        {
            var actividad = await _actividadRepo.GetByIdAsync(id);
            if (actividad == null || !actividad.Activo) return false;

            actividad.Nombre = actividadDto.Nombre;
            actividad.Tipo = actividadDto.Tipo;
            actividad.Fecha = actividadDto.Fecha;
            actividad.DuracionMinutos = actividadDto.DuracionMinutos;
            actividad.CaloriasQuemadas = actividadDto.CaloriasQuemadas;
            actividad.Notas = actividadDto.Notas;
            actividad.FechaModificacion = DateTime.UtcNow;

            await _actividadRepo.UpdateAsync(actividad);
            return true;
        }

        public async Task<bool> EliminarActividadAsync(int id)
        {
            var actividad = await _actividadRepo.GetByIdAsync(id);
            if (actividad == null) return false;

            actividad.Activo = false;
            actividad.FechaModificacion = DateTime.UtcNow;

            await _actividadRepo.UpdateAsync(actividad);
            return true;
        }
    }
}
