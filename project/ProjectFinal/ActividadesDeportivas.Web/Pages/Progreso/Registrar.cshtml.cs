using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActividadesDeportivas.Application.Dtos.ProgresoEstadistica;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class ProgresoRegistrarModel : PageModel
{
    private readonly HttpClient _httpClient;

    public ProgresoRegistrarModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [BindProperty]
    public RegistrarProgresoDto Progreso { get; set; } = new RegistrarProgresoDto();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7128/api/progreso/1", Progreso);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToPage("Index");
        }

        ModelState.AddModelError(string.Empty, "No se pudo registrar el progreso.");
        return Page();
    }
}
