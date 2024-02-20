using Microsoft.Extensions.DependencyInjection;
 
using System.Reflection;
 
using EntregarWorker.Domain.Repositories;

using MongoDB.Driver;
using Confluent.Kafka;
using EntregarWorker.Domain.Service.Events;
using EntregarWorker.Infrastructure.Services.Events;
using System.Net;
 
using Microsoft.Extensions.Configuration;
 using Polly.Extensions.Http;
using Polly;
using EntregarWorker.CrossCutting.Configs;


namespace EntregarWorker.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfraestructure(
            this IServiceCollection services, IConfiguration configInfo

            )
        {
            var appConfiguration = new AppConfiguration(configInfo);

            services.AddDataBaseFactories(appConfiguration.ConexionDBPagos);

          //  services.AddDataBaseFactories(configInfo);
            services.AddRepositories(Assembly.GetExecutingAssembly());
            services.AddProducer(appConfiguration.UrlBaseServicioKafka);
            services.AddEventServices();
            services.AddConsumer(appConfiguration.UrlBaseServicioKafka);
        } 

        //private static void AddDataBaseFactories(this IServiceCollection services, IConfiguration configInfo)
        //{
        //    var appConfiguration = new AppConfiguration(configInfo);
        //    services.AddSingleton(mongoDatabase =>
        //    {
        //        var mongoClient = new MongoClient(appConfiguration.ConexionDBStocks);
        //        return mongoClient.GetDatabase(appConfiguration.NombreDBStocks);
        //        //var mongoClient = new MongoClient(connectionString);
        //        //return mongoClient.GetDatabase("db-productos-stocks");
        //    });

        //}

        private static void AddDataBaseFactories(this IServiceCollection services, string connectionString)
        {
           // var appConfiguration = new AppConfiguration(configInfo);
            services.AddSingleton(mongoDatabase =>
            {
                var mongoClient = new MongoClient(connectionString);
                return mongoClient.GetDatabase("db-pagos-ventas");
            
            });

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
                Console.WriteLine(result);
            }
            ;
            Action onReset = null;
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30),
                onBreak, onReset
                );


        }

        private static IAsyncPolicy<HttpResponseMessage> GetBulkHeadPolicy()
        {
            return Policy.BulkheadAsync<HttpResponseMessage>(1000, int.MaxValue);
        }



        public static void AddRepositories(this IServiceCollection services, Assembly assembly)

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

        private static IServiceCollection AddProducer(this IServiceCollection services, string connectionString)
        {
           // var appConfiguration = new AppConfiguration(configInfo);
            var config = new ProducerConfig
            {
                Acks = Acks.Leader,
                BootstrapServers = connectionString,
                //BootstrapServers = "host.docker.internal:29092",
                //BootstrapServers = "127.0.0.1:9092", 
                ClientId = Dns.GetHostName(),
            };

            services.AddSingleton<IPublisherFactory>(sp => new PublisherFactory(config));
            return services;
        }

        private static IServiceCollection AddConsumer(this IServiceCollection services, string connectionString)
        {
           // var appConfiguration = new AppConfiguration(configInfo);
            var config = new ConsumerConfig
            {
                BootstrapServers = connectionString,
               // GroupId = appConfiguration.GrupoIdString,
                // BootstrapServers = "127.0.0.1:9092",
                GroupId = "venta-actualizar-stocks",
                AutoOffsetReset = AutoOffsetReset.Latest
            };

            services.AddSingleton<IConsumerFactory>(sp => new ConsumerFactory(config));
            return services;
        }

        private static void AddEventServices(this IServiceCollection services)
        {
            services.AddSingleton<IEventSender, EventSender>();
        }
    }
}
