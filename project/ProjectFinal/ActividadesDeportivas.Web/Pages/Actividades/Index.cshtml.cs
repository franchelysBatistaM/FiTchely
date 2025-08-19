using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActividadesDeportivas.Application.Dtos.ActividadFisica;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

public class ActividadesIndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public ActividadesIndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    public List<ActividadFisicaDetalleDto> Actividades { get; set; } = new();

    public async Task OnGetAsync()
    {

        Actividades = await _httpClient.GetFromJsonAsync<List<ActividadFisicaDetalleDto>>("https://localhost:7128/api/actividades/1")
                       ?? new List<ActividadFisicaDetalleDto>();

    }

    public async Task<IActionResult> OnPostEliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"https://localhost:7128/api/actividades/{id}");
        return RedirectToPage();
    }
}
