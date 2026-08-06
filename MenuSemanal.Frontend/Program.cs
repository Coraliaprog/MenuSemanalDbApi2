using MenuSemanal.Frontend.Components;
using MenuSemanal.Frontend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("MenuSemanalAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7220/");
});

builder.Services.AddScoped<MenuSemanalService>();
builder.Services.AddScoped<ComidaService>();
builder.Services.AddScoped<IngredienteService>();
builder.Services.AddScoped<ListaCompraService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute(
    "/not-found",
    createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();