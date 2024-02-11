using Steeltoe.Extensions.Configuration.ConfigServer;
using Stocks.Api.Middleware;
using Stocks.Application;
using Stocks.Infrastructure;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddServiceDiscovery(o => o.UseEureka());
builder.Configuration.AddConfigServer(
    LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
      //  builder.Services.AddServiceDiscovery(o => o.UseEureka());

    })
    );
// Add or register service discovery to your application


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
