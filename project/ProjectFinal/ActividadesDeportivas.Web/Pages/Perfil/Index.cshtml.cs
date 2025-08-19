using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActividadesDeportivas.Application.Dtos.UsuarioDeportivo;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class PerfilIndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public PerfilIndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [BindProperty]
    public UsuarioDeportivoDto Usuario { get; set; } = new UsuarioDeportivoDto();

    private int UsuarioId => 1;

    public async Task OnGetAsync()
    {
        Usuario = await _httpClient.GetFromJsonAsync<UsuarioDeportivoDto>($"https://localhost:7128/api/usuarios/{UsuarioId}")
                  ?? new UsuarioDeportivoDto();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = new RegistroUsuarioDto
        {
            Nombre = Usuario.Nombre,
            Apellido = Usuario.Apellido,
            Email = Usuario.Email,
            Edad = Usuario.Edad,
            Peso = Usuario.Peso,
            Altura = Usuario.Altura,
            Password = "" 
        };

        var response = await _httpClient.PutAsJsonAsync($"https://localhost:7128/api/usuarios/{UsuarioId}", dto);
        if (response.IsSuccessStatusCode)
            TempData["Mensaje"] = "Perfil actualizado";
        else
            TempData["Error"] = "No se pudo actualizar el perfil";

        return RedirectToPage();
    }
}
