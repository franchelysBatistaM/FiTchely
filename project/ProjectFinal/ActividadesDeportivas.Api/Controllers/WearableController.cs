using ActividadesDeportivas.Api.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace ActividadesDeportivas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WearableController : ControllerBase
    {
        private readonly FitbitSettings _fitbitSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public WearableController(IOptions<FitbitSettings> fitbitOptions, IHttpClientFactory httpClientFactory)
        {
            _fitbitSettings = fitbitOptions.Value;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            var url = $"https://www.fitbit.com/oauth2/authorize" +
                      $"?response_type=code" +
                      $"&client_id={_fitbitSettings.ClientId}" +
                      $"&redirect_uri={Uri.EscapeDataString(_fitbitSettings.RedirectUri)}" +
                      $"&scope=activity%20heartrate%20profile";

            return Redirect(url);
        }

        [HttpGet("callback")]
        public async Task<IActionResult> Callback([FromQuery] string code)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest("Código de autorización no recibido.");

            var client = _httpClientFactory.CreateClient();

            var authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_fitbitSettings.ClientId}:{_fitbitSettings.ClientSecret}"));

            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.fitbit.com/oauth2/token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", _fitbitSettings.ClientId },
                { "grant_type", "authorization_code" },
                { "redirect_uri", _fitbitSettings.RedirectUri },
                { "code", code }
            });

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return Ok(content);
        }

        [HttpGet("datos")]
        public async Task<IActionResult> ObtenerDatosDelDia([FromQuery] string accessToken)
        {
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var today = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var url = $"https://api.fitbit.com/1/user/-/activities/date/{today}.json";

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return BadRequest($"Error desde Fitbit: {content}");

            return Ok(content);
        }
    }
}
