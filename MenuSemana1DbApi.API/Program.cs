using System.Text.Json.Serialization;
using Aplicacion.Service;
using Infraestructura.AccesoDatos.Contexto;
using Infraestructura.AccesoDatos.Interfaces;
using Infraestructura.AccesoDatos.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MenuSemanalDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection")));

builder.Services.AddScoped<
    IComidaRepository,
    ComidaRepository>();

builder.Services.AddScoped<
    IIngredienteRepository,
    IngredienteRepository>();

builder.Services.AddScoped<
    IListaCompraRepository,
    ListaCompraRepository>();

builder.Services.AddScoped<
    IMenuSemanalRepository,
    MenuSemanalRepository>();

builder.Services.AddScoped<ComidaService>();
builder.Services.AddScoped<IngredienteService>();
builder.Services.AddScoped<ListaCompraService>();
builder.Services.AddScoped<MenuSemanalService>();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();