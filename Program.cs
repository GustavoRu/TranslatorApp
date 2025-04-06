var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// etc.

var app = builder.Build();

// Mapear controladores.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Busca y registra los controladores.
});

app.Run();
