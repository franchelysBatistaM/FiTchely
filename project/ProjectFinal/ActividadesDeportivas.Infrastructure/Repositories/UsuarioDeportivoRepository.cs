using System.Threading.Tasks;
using ActividadesDeportivas.Domain.Entities;
using ActividadesDeportivas.Infrastructure.Context;
using ActividadesDeportivas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ActividadesDeportivas.Infrastructure.Repositories
{
    public class UsuarioDeportivoRepository : GenericRepository<UsuarioDeportivo>, IUsuarioDeportivoRepository
    {
        private readonly ActividadesDbContext _db;

        public UsuarioDeportivoRepository(ActividadesDbContext context) : base(context)
        {
            _db = context;
        }

        public async Task<UsuarioDeportivo?> GetByEmailAsync(string email)
        {
            return await _db.UsuariosDeportivos
                .Include(u => u.Actividades)
                .Include(u => u.EstadisticasProgreso)
                .Include(u => u.ResumenesDiarios)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _db.UsuariosDeportivos.AnyAsync(u => u.Email == email);
        }
    }
}
