using ActividadesDeportivas.Application.Contracts;
using ActividadesDeportivas.Application.Dtos.UsuarioDeportivo;
using Microsoft.AspNetCore.Mvc;

namespace ActividadesDeportivas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntrarController : ControllerBase
    {
        private readonly IUsuarioDeportivoService _usuarioService;

        public EntrarController(IUsuarioDeportivoService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registrar([FromBody] RegistroUsuarioDto dto)
        {
            var usuario = await _usuarioService.RegistrarUsuarioAsync(dto);
            return Ok(usuario);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioDto dto)
        {
            var usuario = await _usuarioService.LoginAsync(dto);

            if (usuario == null)
                return Unauthorized(new { Mensaje = "Credenciales inválidas" });

            return Ok(usuario);
        }
    }
}
