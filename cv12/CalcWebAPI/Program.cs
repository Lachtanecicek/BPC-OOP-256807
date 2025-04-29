using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CalcWebAPI;

var builder = WebApplication.CreateBuilder(args);

// Pøidáme služby pro API
builder.Services.AddControllers();

var app = builder.Build();

// Pøidáme mapování na API
app.MapControllers();

app.Run();
