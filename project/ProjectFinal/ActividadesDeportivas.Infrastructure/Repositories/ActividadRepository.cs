using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActividadesDeportivas.Domain.Entities;
using ActividadesDeportivas.Infrastructure.Context;
using ActividadesDeportivas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ActividadesDeportivas.Infrastructure.Repositories
{
    public class ActividadRepository : GenericRepository<ActividadFisica>, IActividadRepository
    {
        private readonly ActividadesDbContext _db;

        public ActividadRepository(ActividadesDbContext context) : base(context)
        {
            _db = context;
        }

        public async Task<IEnumerable<ActividadFisica>> GetByUsuarioAsync(int usuarioId)
        {
            return await _db.ActividadesFisicas
                .Where(a => a.UsuarioDeportivoId == usuarioId && a.Activo)
                .ToListAsync();
        }
    }
}
