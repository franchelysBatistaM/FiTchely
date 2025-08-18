using ActividadesDeportivas.Application.Contracts;
using ActividadesDeportivas.Application.Dtos.ProgresoEstadistica;
using Microsoft.AspNetCore.Mvc;

namespace ActividadesDeportivas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgresoController : ControllerBase
    {
        private readonly IEstadisticaProgresoService _progresoService;

        public ProgresoController(IEstadisticaProgresoService progresoService)
        {
            _progresoService = progresoService;
        }

        [HttpPost("{usuarioId}")]
        public async Task<IActionResult> RegistrarProgreso(int usuarioId, [FromBody] RegistrarProgresoDto progresoDto)
        {
            var progreso = await _progresoService.RegistrarProgresoAsync(progresoDto, usuarioId);
            if (progreso == null) return BadRequest("No se pudo registrar el progreso.");
            return Ok(progreso);
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> ObtenerProgresosPorUsuario(int usuarioId)
        {
            var progresos = await _progresoService.GetProgresoByUsuarioIdAsync(usuarioId);
            return Ok(progresos);
        }
    }
}
