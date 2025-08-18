using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadesDeportivas.Application.Dtos.ProgresoEstadistica;


namespace ActividadesDeportivas.Application.Contracts
{
    public interface IEstadisticaProgresoService
    {
        Task<List<ProgresoEstadisticaDto>> GetProgresoByUsuarioIdAsync(int usuarioId);
        Task<ProgresoEstadisticaDto?> RegistrarProgresoAsync(RegistrarProgresoDto progresoDto, int usuarioId);
    }

}
