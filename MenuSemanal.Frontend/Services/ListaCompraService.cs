using System.Net.Http.Json;
using MenuSemanal.Frontend.Models;

namespace MenuSemanal.Frontend.Services;

public class ListaCompraService
{
    private readonly HttpClient _httpClient;

    public ListaCompraService(
        IHttpClientFactory httpClientFactory)
    {
        _httpClient =
            httpClientFactory.CreateClient("MenuSemanalAPI");
    }

    public async Task<List<ListaCompra>> ObtenerTodasAsync()
    {
        return await _httpClient
            .GetFromJsonAsync<List<ListaCompra>>(
                "api/ListasCompra") ?? [];
    }

    public async Task CrearAsync(ListaCompra producto)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/ListasCompra",
            producto);

        response.EnsureSuccessStatusCode();
    }

    public async Task ActualizarAsync(ListaCompra producto)
    {
        var response = await _httpClient.PutAsJsonAsync(
            $"api/ListasCompra/{producto.Id}",
            producto);

        response.EnsureSuccessStatusCode();
    }

    public async Task EliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync(
            $"api/ListasCompra/{id}");

        response.EnsureSuccessStatusCode();
    }
}