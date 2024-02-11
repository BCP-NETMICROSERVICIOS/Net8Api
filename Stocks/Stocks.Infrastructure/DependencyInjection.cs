using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Stocks.Domain.Repositories;
using Stocks.Infrastructure.Repositories;
using MongoDB.Driver;
using Confluent.Kafka;
using Stocks.Domain.Service.Events;
using Stocks.Infrastructure.Services.Events;
using System.Net;
using Microsoft.Extensions.Configuration;
using Stock.CrossCutting.Configs;
using MongoDB.Driver.Core.Configuration;
using Polly;
using Polly.Extensions.Http;


namespace Stocks.Infrastructure
{
    public static class DependencyInjection
    {


         

       // public static object AppConfiguration { get => appConfiguration; set => appConfiguration = value; }

        //public static void AddInfraestructure(
        //    this IServiceCollection services, string connectionString
        //    )

        public static void AddInfraestructure(
            this IServiceCollection services, IConfiguration configInfo)
        {

            services.AddDataBaseFactories(configInfo);
              
            services.AddRepositories(Assembly.GetExecutingAssembly());
             services.AddProducer(configInfo);
            services.AddEventServices();
            

        }

        //private static void AddDataBaseFactories(this IServiceCollection services, string connectionString)
        private static void AddDataBaseFactories(this IServiceCollection services, IConfiguration configInfo)
        {
            var appConfiguration = new AppConfiguration(configInfo);

            services.AddSingleton(mongoDatabase =>
            {
                var mongoClient = new MongoClient(appConfiguration.ConexionDBStocks);
                return mongoClient.GetDatabase(appConfiguration.NombreDBStocks);
                // var mongoClient = new MongoClient(connectionString);
               // return mongoClient.GetDatabase("db-productos-stocks");
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


        //private static void AddRepositories(this IServiceCollection services)
        //{
        //    services.AddScoped<IProductoRepository, ProductoRepository>();


        //}

        public static void  AddRepositories(this IServiceCollection services, Assembly assembly)

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
    }
}
