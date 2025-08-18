using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadesDeportivas.Application.Dtos.ResumenFitbit;


namespace ActividadesDeportivas.Application.Contracts
{
    public interface IResumenFitbitService
    {
        Task GuardarResumenAsync(ResumenFitbitDto resumen, int usuarioId);
    }

}
