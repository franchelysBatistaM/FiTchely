using Microsoft.AspNetCore.Mvc.RazorPages;
using ActividadesDeportivas.Application.Dtos.ProgresoEstadistica;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class ProgresoIndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public ProgresoIndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    public List<ProgresoEstadisticaDto> Progresos { get; set; } = new();

    public async Task OnGetAsync()
    {
        Progresos = await _httpClient.GetFromJsonAsync<List<ProgresoEstadisticaDto>>("https://localhost:7128/api/progreso/1")
                   ?? new List<ProgresoEstadisticaDto>();
    }
}
