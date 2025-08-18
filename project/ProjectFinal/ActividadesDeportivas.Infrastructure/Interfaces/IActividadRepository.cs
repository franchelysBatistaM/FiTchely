using System.Collections.Generic;
using System.Threading.Tasks;
using ActividadesDeportivas.Domain.Entities;

namespace ActividadesDeportivas.Infrastructure.Interfaces
{
    public interface IActividadRepository : IGenericRepository<ActividadFisica>
    {
        Task<IEnumerable<ActividadFisica>> GetByUsuarioAsync(int usuarioId);
    }
}
