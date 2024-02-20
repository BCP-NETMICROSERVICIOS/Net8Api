
using EntregarWorker.Domain.Service.Events;
using static Confluent.Kafka.ConfigPropertyNames;
using System.Threading;
using MediatR;
using Newtonsoft.Json;



using EntregarWorker.Application.CasosUso.AdministrarEntregas.RegistrarEntrega;
using System.Text.Json.Serialization;
using System.Text.Json;
using EntregarWorker.Domain.Models;
using Confluent.Kafka;

namespace EntregarWorker.Worker.Workers
{
    public class ActualizarEntregasWorker : BackgroundService
    {
        private readonly IConsumerFactory _consumerFactory;
      //  private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;
        public ActualizarEntregasWorker(IConsumerFactory consumerFactory, IServiceProvider serviceProvider) {
            _consumerFactory = consumerFactory;
            _serviceProvider = serviceProvider;
            //_mediator = mediator;
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumer = _consumerFactory.GetConsumer();
            consumer.Subscribe("pagos");

            while (!cancellationToken.IsCancellationRequested)
            {
                //var consumeResult = consumer.Consume(cancellationToken);
                // var data = 1;
                using var scope = _serviceProvider.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                var consumeResult = consumer.Consume(cancellationToken);

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.WriteIndented = true;
                options.IncludeFields = true;
              //  response = client.GetAsync(consumeResult.Value).Result;
               // resultado = response.Content.ReadAsStringAsync().Result
             
                
               
                RegistrarPedidoRequest request = JsonConvert.DeserializeObject<RegistrarPedidoRequest>(consumeResult.Value);
                await mediator.Send(request);
             
            }

            consumer.Close();

          //  return Task.CompletedTask;
        }
    }
}
