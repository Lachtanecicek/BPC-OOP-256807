using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CalcWebAPI;

var builder = WebApplication.CreateBuilder(args);

// P�id�me slu�by pro API
builder.Services.AddControllers();

var app = builder.Build();

// P�id�me mapov�n� na API
app.MapControllers();

app.Run();
