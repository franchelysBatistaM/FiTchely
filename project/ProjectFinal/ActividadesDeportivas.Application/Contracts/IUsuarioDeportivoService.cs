using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadesDeportivas.Application.Dtos.UsuarioDeportivo;

namespace ActividadesDeportivas.Application.Contracts
{
    public interface IUsuarioDeportivoService
    {
        Task<UsuarioDeportivoDto?> RegistrarUsuarioAsync(RegistroUsuarioDto registroDto);
        Task<UsuarioDeportivoDto?> LoginAsync(LoginUsuarioDto loginDto);
        Task<bool> EliminarUsuarioAsync(int id);
        Task<bool> ValidarContrasenaAsync(int id, string password);
        Task<UsuarioDeportivoDto?> GetUsuarioByIdAsync(int id);
        Task<UsuarioDeportivoDto?> GetUsuarioByEmailAsync(string email);

        Task<bool> ActualizarUsuarioAsync(int id, RegistroUsuarioDto dto);
    }

}
