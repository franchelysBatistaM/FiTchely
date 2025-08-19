using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActividadesDeportivas.Application.Dtos.ResumenFitbit;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class FitbitIndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public FitbitIndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    public bool Conectado { get; set; } = false;
    public ResumenFitbitDto Datos { get; set; } = new ResumenFitbitDto();

    private int UsuarioId => 1;

    public async Task OnGetAsync(string accessToken)
    {
        if (!string.IsNullOrEmpty(accessToken))
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.GetAsync("https://localhost:7128/api/wearable/datos");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);
                    var summary = doc.RootElement.GetProperty("summary");

                    Datos.CaloriasQuemadas = summary.GetProperty("caloriesOut").GetInt32();
                    Datos.MinutosSedentarios = summary.GetProperty("sedentaryMinutes").GetInt32();
                    Conectado = true;
                }
            }
            catch
            {
            }
        }
    }

    public IActionResult OnGetConectar()
    {
        return Page();
    }
}
