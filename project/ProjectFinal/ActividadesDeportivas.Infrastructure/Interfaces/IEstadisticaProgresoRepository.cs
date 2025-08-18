using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ActividadesDeportivas.Domain.Entities;

namespace ActividadesDeportivas.Infrastructure.Interfaces
{
    public interface IEstadisticaProgresoRepository : IGenericRepository<EstadisticaProgreso>
    {
        Task<IEnumerable<EstadisticaProgreso>> GetByUsuarioAsync(int usuarioId);
    }
}