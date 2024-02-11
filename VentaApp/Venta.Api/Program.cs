using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.OpenApi.Models;
using Steeltoe.Extensions.Configuration.ConfigServer;
using System.Runtime.CompilerServices;
using Venta.Api;
using Venta.Api.Configurations;
using Venta.Api.Middleware;
using Venta.Application;
using Venta.Infrastructure;
using Microsoft.Extensions.Logging;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddConfigServer(
    LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    })
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Capa de aplicacion
builder.Services.AddApplication();

//Capa de infra

//var connectionString = builder.Configuration.GetConnectionString("dbVenta-cnx");
var connectionString = builder.Configuration["dbVenta-cnx"];
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddAthenticationByJWT();
builder.Services.AddHealthCheckConfiguration(builder.Configuration);
//CODIGO

builder.Services.AddSwaggerGen(config =>
{
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseHealthCheckConfiguration();


//Adicionar middleware customizado para tratar las excepciones
app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
