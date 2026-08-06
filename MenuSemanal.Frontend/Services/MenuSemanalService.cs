using System.Net.Http.Json;
using MenuSemanal.Frontend.Models;

namespace MenuSemanal.Frontend.Services;

public class MenuSemanalService
{
    private readonly HttpClient _httpClient;

    public MenuSemanalService(
        IHttpClientFactory httpClientFactory)
    {
        _httpClient =
            httpClientFactory.CreateClient("MenuSemanalAPI");
    }

    public async Task<List<MenuSemanalModel>> ObtenerTodosAsync()
    {
        return await _httpClient
            .GetFromJsonAsync<List<MenuSemanalModel>>(
                "api/MenusSemanales") ?? [];
    }

    public async Task CrearAsync(MenuSemanalModel menu)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/MenusSemanales",
            menu);

        response.EnsureSuccessStatusCode();
    }

    public async Task ActualizarAsync(MenuSemanalModel menu)
    {
        var response = await _httpClient.PutAsJsonAsync(
            $"api/MenusSemanales/{menu.Id}",
            menu);

        response.EnsureSuccessStatusCode();
    }

    public async Task EliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync(
            $"api/MenusSemanales/{id}");

        response.EnsureSuccessStatusCode();
    }
}
