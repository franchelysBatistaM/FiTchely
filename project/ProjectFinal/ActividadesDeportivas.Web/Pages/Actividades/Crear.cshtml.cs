using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActividadesDeportivas.Application.Dtos.ActividadFisica;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class ActividadesCrearModel : PageModel
{
    private readonly HttpClient _httpClient;

    public ActividadesCrearModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [BindProperty]
    public CrearActividadFisicaDto Actividad { get; set; } = new CrearActividadFisicaDto();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {

        var response = await _httpClient.PostAsJsonAsync("https://localhost:7128/api/actividades/1", Actividad);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToPage("Index");
        }
        ModelState.AddModelError(string.Empty, "No se pudo crear la actividad.");
        return Page();
    }
}
