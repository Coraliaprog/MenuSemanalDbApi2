using System.Net.Http.Json;
using MenuSemanal.Frontend.Models;

namespace MenuSemanal.Frontend.Services;

public class ComidaService
{
    private readonly HttpClient _httpClient;

    public ComidaService(IHttpClientFactory httpClientFactory)
    {
        _httpClient =
            httpClientFactory.CreateClient("MenuSemanalAPI");
    }

    public async Task<List<Comida>> ObtenerTodasAsync()
    {
        return await _httpClient
            .GetFromJsonAsync<List<Comida>>("api/Comidas") ?? [];
    }

    public async Task CrearAsync(Comida comida)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/Comidas",
            comida);

        response.EnsureSuccessStatusCode();
    }

    public async Task ActualizarAsync(Comida comida)
    {
        var response = await _httpClient.PutAsJsonAsync(
            $"api/Comidas/{comida.Id}",
            comida);

        response.EnsureSuccessStatusCode();
    }

    public async Task EliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync(
            $"api/Comidas/{id}");

        response.EnsureSuccessStatusCode();
    }
}