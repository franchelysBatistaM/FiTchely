using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ActividadesDeportivas.Domain.Entities;

namespace ActividadesDeportivas.Infrastructure.Interfaces
{
    public interface IUsuarioDeportivoRepository
    {
        Task<UsuarioDeportivo?> GetByIdAsync(int id);
        Task<UsuarioDeportivo?> GetByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);
        Task AddAsync(UsuarioDeportivo usuario);
        Task UpdateAsync(UsuarioDeportivo usuario);
        Task DeleteAsync(UsuarioDeportivo usuario);
    }
}