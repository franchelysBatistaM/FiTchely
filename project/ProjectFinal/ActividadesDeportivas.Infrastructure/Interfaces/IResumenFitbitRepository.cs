using System;
using System.Threading.Tasks;
using ActividadesDeportivas.Domain.Entities;

namespace ActividadesDeportivas.Infrastructure.Interfaces
{
    public interface IResumenFitbitRepository : IGenericRepository<ResumenDiarioFitbit>
    {
        Task<ResumenDiarioFitbit?> GetByUsuarioAndFechaAsync(int usuarioId, DateTime fecha);
    }
}
