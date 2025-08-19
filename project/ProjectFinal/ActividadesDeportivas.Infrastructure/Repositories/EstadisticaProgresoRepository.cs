using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActividadesDeportivas.Domain.Entities;
using ActividadesDeportivas.Infrastructure.Context;
using ActividadesDeportivas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ActividadesDeportivas.Infrastructure.Repositories
{
    public class EstadisticaProgresoRepository : GenericRepository<EstadisticaProgreso>, IEstadisticaProgresoRepository
    {
        private readonly ActividadesDbContext _db;

        public EstadisticaProgresoRepository(ActividadesDbContext context) : base(context)
        {
            _db = context;
        }

        public async Task<IEnumerable<EstadisticaProgreso>> GetByUsuarioAsync(int usuarioId)
        {
            return await _db.EstadisticasProgreso
                .Where(e => e.UsuarioDeportivoId == usuarioId && e.Activo)
                .OrderByDescending(e => e.Fecha)
                .ToListAsync();
        }
    }
}
