using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadesDeportivas.Application.Dtos;
using ActividadesDeportivas.Application.Dtos.ActividadFisica;


namespace ActividadesDeportivas.Application.Contracts
{
    public interface IActividadFisicaService
    {
        Task<ActividadFisicaDto?> CrearActividadAsync(CrearActividadFisicaDto actividadDto, int usuarioId);
        Task<List<ActividadFisicaDto>> ObtenerPorUsuarioAsync(int usuarioId);
        Task<bool> ActualizarActividadAsync(int id, ActualizarActividadFisicaDto actividadDto);
        Task<bool> EliminarActividadAsync(int id);
    }

}
