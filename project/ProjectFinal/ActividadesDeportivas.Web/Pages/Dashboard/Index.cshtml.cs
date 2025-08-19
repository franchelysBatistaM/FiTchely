using Microsoft.AspNetCore.Mvc.RazorPages;
using ActividadesDeportivas.Application.Dtos.ActividadFisica;
using ActividadesDeportivas.Application.Dtos.ProgresoEstadistica;
using ActividadesDeportivas.Application.Dtos.ResumenFitbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class DashboardIndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public DashboardIndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    public List<ActividadFisicaDetalleDto> ActividadesHoy { get; set; } = new();
    public List<ProgresoEstadisticaDto> Progresos { get; set; } = new();
    public ResumenFitbitDto Fitbit { get; set; } = new();
    public float TotalCalorias => ActividadesHoy.Sum(a => a.CaloriasQuemadas)
                                  + (Fitbit?.CaloriasQuemadas ?? 0);

    private int UsuarioId => 1;

    public async Task OnGetAsync()
    {
        var todas = await _httpClient.GetFromJsonAsync<List<ActividadFisicaDetalleDto>>(
            $"https://localhost:7128/api/actividades/{UsuarioId}"
        );

        ActividadesHoy = todas ?? new();

        var progresos = await _httpClient.GetFromJsonAsync<List<ProgresoEstadisticaDto>>(
            $"https://localhost:7128/api/progreso/{UsuarioId}"
        );
        Progresos = progresos?
            .OrderByDescending(p => p.Fecha)
            .Take(7)
            .OrderBy(p => p.Fecha)
            .ToList() ?? new();

        var fitbit = await _httpClient.GetFromJsonAsync<ResumenFitbitDto[]>(
            $"https://localhost:7128/api/wearable/datos?accessToken=ACCESS_TOKEN"
        ) ?? Array.Empty<ResumenFitbitDto>();

        Fitbit = fitbit.FirstOrDefault() ?? new ResumenFitbitDto();
    }
}
