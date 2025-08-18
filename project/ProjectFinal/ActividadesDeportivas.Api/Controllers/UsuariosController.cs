using ActividadesDeportivas.Application.Contracts;
using ActividadesDeportivas.Application.Dtos.UsuarioDeportivo;
using Microsoft.AspNetCore.Mvc;

namespace ActividadesDeportivas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioDeportivoService _usuarioService;

        public UsuariosController(IUsuarioDeportivoService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] RegistroUsuarioDto dto)
        {
            var usuarioCreado = await _usuarioService.RegistrarUsuarioAsync(dto);
            if (usuarioCreado == null)
                return BadRequest("No se pudo registrar el usuario.");

            return CreatedAtAction(nameof(GetUsuario), new { id = usuarioCreado.Id }, usuarioCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] RegistroUsuarioDto dto)
        {
            var actualizado = await _usuarioService.ActualizarUsuarioAsync(id, dto);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var eliminado = await _usuarioService.EliminarUsuarioAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}
