using ActividadesDeportivas.Application.Contracts;
using ActividadesDeportivas.Application.Dtos.ActividadFisica;
using Microsoft.AspNetCore.Mvc;

namespace ActividadesDeportivas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActividadesController : ControllerBase
    {
        private readonly IActividadFisicaService _actividadService;

        public ActividadesController(IActividadFisicaService actividadService)
        {
            _actividadService = actividadService;
        }

        [HttpPost("{usuarioId}")]
        public async Task<IActionResult> CrearActividad(int usuarioId, [FromBody] CrearActividadFisicaDto actividadDto)
        {
            var actividad = await _actividadService.CrearActividadAsync(actividadDto, usuarioId);
            if (actividad == null) return BadRequest("No se pudo crear la actividad.");
            return Ok(actividad);
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> ObtenerPorUsuario(int usuarioId)
        {
            var actividades = await _actividadService.ObtenerPorUsuarioAsync(usuarioId);
            return Ok(actividades);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarActividad(int id, [FromBody] ActualizarActividadFisicaDto actividadDto)
        {
            var actualizado = await _actividadService.ActualizarActividadAsync(id, actividadDto);
            if (!actualizado) return NotFound("Actividad no encontrada o inactiva.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarActividad(int id)
        {
            var eliminado = await _actividadService.EliminarActividadAsync(id);
            if (!eliminado) return NotFound("Actividad no encontrada.");
            return NoContent();
        }
    }
}
