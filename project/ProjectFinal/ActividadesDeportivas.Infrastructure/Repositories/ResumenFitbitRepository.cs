using ActividadesDeportivas.Domain.Entities;
using ActividadesDeportivas.Infrastructure.Context;
using ActividadesDeportivas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesDeportivas.Infrastructure.Repositories
{
    public class ResumenFitbitRepository : GenericRepository<ResumenDiarioFitbit>, IResumenFitbitRepository
    {

        public ResumenFitbitRepository(ActividadesDbContext context) : base(context)
        {

        }

        public async Task<ResumenDiarioFitbit?> GetByUsuarioAndFechaAsync(int usuarioId, DateTime fecha)
        {
            return await _context.ResumenesDiariosFitbit
                                 .Where(r => r.UsuarioDeportivoId == usuarioId && r.Fecha.Date == fecha.Date)
                                 .FirstOrDefaultAsync();
        }
    }
}
