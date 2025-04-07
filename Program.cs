var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Nuestra inyección
builder.Services.AddScoped<ITranslationService, TranslationService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Mapear controladores.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Busca y registra los controladores.
});

app.Run();
