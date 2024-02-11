using Steeltoe.Extensions.Configuration.ConfigServer;
using Venta.Worker.Middleware;
using VentaWorker.Application;
using VentaWorker.Infrastructure;
using Venta.Worker.Workers;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using VentaWorker.Domain.Service.WebServices;
using VentaWorker.Infrastructure.Services.WebServices;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);

//
//builder.Services.AddServiceDiscovery(o => o.UseEureka());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
//Capa de aplicacion
builder.Services.AddApplication();

//Capa de infra
//var connectionString = builder.Configuration.GetConnectionString("dbStocks-cnx");
//builder.Services.AddInfraestructure(connectionString);
var connectionString = builder.Configuration["dbStocks-cnx"];
builder.Services.AddInfraestructure(builder.Configuration);

builder.Services.AddHttpClient();
builder.Services.AddScoped<IProductoService, ProductoService>();

//Adiconando el background service
builder.Services.AddHostedService<ActualizarStocksWorker>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Adicionar middleware customizado para tratar las excepciones
app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
