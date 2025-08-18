using ActividadesDeportivas.Application.Contracts;
using ActividadesDeportivas.Application.Dtos.UsuarioDeportivo;
using ActividadesDeportivas.Domain.Entities;
using ActividadesDeportivas.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ActividadesDeportivas.Application.Services
{
    public class UsuarioDeportivoService : IUsuarioDeportivoService
    {
        private readonly IUsuarioDeportivoRepository _usuarioRepo;

        public UsuarioDeportivoService(IUsuarioDeportivoRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task<UsuarioDeportivoDto?> RegistrarUsuarioAsync(RegistroUsuarioDto registroDto)
        {
            var existe = await _usuarioRepo.GetByEmailAsync(registroDto.Email);
            if (existe != null)
                throw new InvalidOperationException("El correo ya está registrado.");

            var (hash, salt) = HashPassword(registroDto.Password);

            var usuario = new UsuarioDeportivo
            {
                Nombre = registroDto.Nombre,
                Apellido = registroDto.Apellido,
                Email = registroDto.Email,
                PasswordHash = hash,
                PasswordSalt = salt, 
                Edad = registroDto.Edad,
                Peso = registroDto.Peso,
                Altura = registroDto.Altura,
                FechaCreacion = DateTime.UtcNow,
                Activo = true
            };

            await _usuarioRepo.AddAsync(usuario);

            return MapToDto(usuario);
        }

        public async Task<UsuarioDeportivoDto?> LoginAsync(LoginUsuarioDto loginDto)
        {
            var usuario = await _usuarioRepo.GetByEmailAsync(loginDto.Email);
            if (usuario == null)
                return null;

            if (!VerifyPassword(loginDto.Password, usuario.PasswordHash, usuario.PasswordSalt))
                return null;

            return MapToDto(usuario);
        }

        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            var usuario = await _usuarioRepo.GetByIdAsync(id);
            if (usuario == null)
                return false;

            await _usuarioRepo.DeleteAsync(usuario);
            return true;
        }

        public async Task<bool> ValidarContrasenaAsync(int id, string password)
        {
            var usuario = await _usuarioRepo.GetByIdAsync(id);
            if (usuario == null)
                return false;

            return VerifyPassword(password, usuario.PasswordHash, usuario.PasswordSalt);
        }

        public async Task<UsuarioDeportivoDto?> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepo.GetByIdAsync(id);
            if (usuario == null)
                return null;

            return MapToDto(usuario);
        }

        public async Task<UsuarioDeportivoDto?> GetUsuarioByEmailAsync(string email)
        {
            var usuario = await _usuarioRepo.GetByEmailAsync(email);
            if (usuario == null)
                return null;

            return MapToDto(usuario);
        }

        public async Task<bool> ActualizarUsuarioAsync(int id, RegistroUsuarioDto dto)
        {
            var usuario = await _usuarioRepo.GetByIdAsync(id);
            if (usuario == null)
                return false;

            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Email = dto.Email;
            usuario.Edad = dto.Edad;
            usuario.Peso = dto.Peso;
            usuario.Altura = dto.Altura;

            if (!string.IsNullOrEmpty(dto.Password))
            {
                var (hash, salt) = HashPassword(dto.Password);
                usuario.PasswordHash = hash;
                usuario.PasswordSalt = salt;
            }

            await _usuarioRepo.UpdateAsync(usuario);
            return true;
        }

        #region Helpers

        private (string hash, string salt) HashPassword(string password)
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
            string salt = Convert.ToBase64String(saltBytes);

            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 32
            ));

            return (hash, salt);
        }

        private bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 32
            ));

            return hash == storedHash;
        }

        private UsuarioDeportivoDto MapToDto(UsuarioDeportivo usuario)
        {
            return new UsuarioDeportivoDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Edad = usuario.Edad,
                Peso = usuario.Peso,
                Altura = usuario.Altura,
                FechaCreacion = usuario.FechaCreacion,
                Activo = usuario.Activo
            };
        }

        #endregion
    }
}
