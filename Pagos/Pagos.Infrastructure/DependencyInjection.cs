using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Pagos.CrossCutting.Configs;
using Pagos.Domain.Repositories;
using Pagos.Domain.Service.Events;
using Pagos.Infrastructure.Repositories.Base;
using Pagos.Infrastructure.Services.Events;
using Polly;
using Polly.Extensions.Http;
using Serilog;
using System.Net;
using System.Reflection;



namespace Pagos.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfraestructure(
            this IServiceCollection services, IConfiguration configInfo
            )
        {
            var appConfiguration = new AppConfiguration(configInfo);




            services.AddDbContext<PagoDbContext>(
                options => options.UseSqlServer(appConfiguration.ConexionDBpagos)
                );

            services.AddRepositories(Assembly.GetExecutingAssembly());
            services.AddProducer(configInfo);
            services.AddEventServices();

            //  services.AddLogger(appConfiguration.LogMongoServerDB, appConfiguration.LogMongoDbCollection);
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(2,
                            retryAttempts => TimeSpan.FromSeconds(Math.Pow(2, retryAttempts)));
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            Action<DelegateResult<HttpResponseMessage>, TimeSpan> onBreak = (result, timeSpan) =>
            {
                //Camino altenativo para llamar a otro servicio failure o publicar en una cola(topico kafka)
                Console.WriteLine(result);
            };


            Action onReset = null;


            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(c => !c.IsSuccessStatusCode)
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30),
                onBreak, onReset
                );


        }

        private static IAsyncPolicy<HttpResponseMessage> GetBulkHeadPolicy()
        {
            return Policy.BulkheadAsync<HttpResponseMessage>(1000, int.MaxValue);
        }


        public static void
                AddRepositories(this IServiceCollection services, Assembly assembly)

        {


            var respositoryTypes = assembly
                .GetExportedTypes().Where(item => item.GetInterface(nameof(IRepository)) != null).ToList();


            foreach (var repositoryType in respositoryTypes)
            {
                var repositoryInterfaceType = repositoryType.GetInterfaces()
                    .Where(item => item.GetInterface(nameof(IRepository)) != null)
                    .First();

                services.AddScoped(repositoryInterfaceType, repositoryType);
            }
        }

        private static IServiceCollection AddProducer(this IServiceCollection services, IConfiguration configInfo)
        {
            // var appConfiguration = new AppConfiguration(configInfo);
            var appConfiguration = new AppConfiguration(configInfo);
            var config = new ProducerConfig
            {
                Acks = Acks.Leader,

                BootstrapServers = appConfiguration.UrlBaseServicioKafka,
                //  BootstrapServers = "host.docker.internal:9092",
                //BootstrapServers = "127.0.0.1:9092",
                ClientId = Dns.GetHostName(),
            };

            services.AddSingleton<IPublisherFactory>(sp => new PublisherFactory(config));
            return services;
        }

        private static void AddEventServices(this IServiceCollection services)
        {
            services.AddSingleton<IEventSender, EventSender>();
        }

        //public static void AddLogger(this IServiceCollection services, string connectionStringDbLog, string collectionName)
        //{
        //    var serilogLogger = new LoggerConfiguration()
        //        //.MinimumLevel.Error()
        //        .MinimumLevel.Information()
        //        .Enrich.FromLogContext()
        //        .WriteTo.MongoDB(connectionStringDbLog, collectionName: collectionName)
        //        .CreateLogger();


        //    services.AddLogging(builder =>
        //    {
        //        builder.AddSerilog(logger: serilogLogger, dispose: true);
        //    });
        //}



    }
}
