using ActividadesDeportivas.Application.Contracts;
using ActividadesDeportivas.Application.Dtos.ResumenFitbit;
using ActividadesDeportivas.Domain.Entities;
using ActividadesDeportivas.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace ActividadesDeportivas.Application.Services
{
    public class ResumenFitbitService : IResumenFitbitService
    {
        private readonly IResumenFitbitRepository _resumenRepo;

        public ResumenFitbitService(IResumenFitbitRepository resumenRepo)
        {
            _resumenRepo = resumenRepo;
        }

        public async Task GuardarResumenAsync(ResumenFitbitDto resumenDto, int usuarioId)
        {
            var resumenExistente = await _resumenRepo.GetByUsuarioAndFechaAsync(usuarioId, resumenDto.Fecha);
            if (resumenExistente != null)
            {
                throw new InvalidOperationException("Ya existe un resumen para esta fecha.");
            }

            var resumenEntity = new ResumenDiarioFitbit
            {
                UsuarioDeportivoId = usuarioId,
                Fecha = resumenDto.Fecha,
                CaloriasQuemadas = resumenDto.CaloriasQuemadas,
                Pasos = resumenDto.Pasos,
                MinutosSedentarios = resumenDto.MinutosSedentarios,
                FechaCreacion = DateTime.UtcNow,
                Activo = true
            };

            await _resumenRepo.AddAsync(resumenEntity);
        }
    }
}
