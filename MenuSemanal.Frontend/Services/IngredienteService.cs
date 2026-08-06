using System.Net.Http.Json;
using MenuSemanal.Frontend.Models;

namespace MenuSemanal.Frontend.Services;

public class IngredienteService
{
    private readonly HttpClient _httpClient;

    public IngredienteService(
        IHttpClientFactory httpClientFactory)
    {
        _httpClient =
            httpClientFactory.CreateClient("MenuSemanalAPI");
    }

    public async Task<List<Ingrediente>> ObtenerTodosAsync()
    {
        return await _httpClient
            .GetFromJsonAsync<List<Ingrediente>>(
                "api/Ingredientes") ?? [];
    }

    public async Task CrearAsync(Ingrediente ingrediente)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/Ingredientes",
            ingrediente);

        response.EnsureSuccessStatusCode();
    }

    public async Task ActualizarAsync(Ingrediente ingrediente)
    {
        var response = await _httpClient.PutAsJsonAsync(
            $"api/Ingredientes/{ingrediente.Id}",
            ingrediente);

        response.EnsureSuccessStatusCode();
    }

    public async Task EliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync(
            $"api/Ingredientes/{id}");

        response.EnsureSuccessStatusCode();
    }
}
