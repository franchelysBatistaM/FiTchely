using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActividadesDeportivas.Application.Dtos.ActividadFisica;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

public class ActividadesEditarModel : PageModel
{
    private readonly HttpClient _httpClient;

    public ActividadesEditarModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [BindProperty]
    public ActualizarActividadFisicaDto Actividad { get; set; } = new ActualizarActividadFisicaDto();

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public int UsuarioId { get; set; } = 1;

    public async Task OnGetAsync()
    {
        try
        {
            var actividades = await _httpClient.GetFromJsonAsync<List<ActividadFisicaDetalleDto>>(
                $"https://localhost:7128/api/actividades/{UsuarioId}");

            var actividad = actividades?.FirstOrDefault(a => a.Id == Id);

            if (actividad != null)
            {
                Actividad = new ActualizarActividadFisicaDto
                {
                    Nombre = actividad.Nombre,
                    Tipo = actividad.Tipo,
                    Fecha = actividad.Fecha,
                    DuracionMinutos = actividad.DuracionMinutos,
                    CaloriasQuemadas = actividad.CaloriasQuemadas,
                    Notas = actividad.Notas
                };
            }
            else
            {

                RedirectToPage("Index");
            }
        }
        catch (HttpRequestException)
        {
            ModelState.AddModelError(string.Empty, "No se pudo conectar con el servidor de la API.");
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _httpClient.PutAsJsonAsync($"https://localhost:7128/api/actividades/{Id}", Actividad);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToPage("Index");
        }

        ModelState.AddModelError(string.Empty, "No se pudo actualizar la actividad.");
        return Page();
    }
}
