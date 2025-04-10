// using TranslatorApp.Automappers;
using TranslatorApp.DTOs;
// using TranslatorApp.Models;
// using TranslatorApp.Repository;
using TranslatorApp.Services;
// using TranslatorApp.Validators;
// using FluentValidation;
// using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITranslationService, TranslationService>();
builder.Services.AddHttpClient<ILyricsService, LyricsService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Agregar estos dos:
app.UseRouting(); // ← Habilita el enrutamiento
app.UseAuthorization(); // ← Por si en el futuro usás autorización

// Mapear controladores
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
