using Microsoft.Extensions.DependencyInjection;
using Venta.CrossCutting.Configs;

namespace Venta.Api.Configurations
{
    public static class HealthCheckConfiguration
    {
        public static IServiceCollection AddHealthCheckConfiguration
            (this IServiceCollection services, IConfiguration configInfo)
        {
            var appConfiguration = new AppConfiguration(configInfo);

            services.AddHealthChecks()
                .AddSqlServer(connectionString: appConfiguration.ConexionDBVentas);

            return services;
        }

        public static IApplicationBuilder UseHealthCheckConfiguration
           (this IApplicationBuilder services)
        {
            services.UseHealthChecks("/health");

            return services;
        }
    }
}
