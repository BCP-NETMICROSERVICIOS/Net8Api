
using EntregarWorker.Domain.Service.Events;
using static Confluent.Kafka.ConfigPropertyNames;
using System.Threading;
using MediatR;

 
using EntregarWorker.Application.CasosUso.AdministrarProductos.ActualizarProductos;

namespace EntregarWorker.Worker.Workers
{
    public class ActualizarEntregasWorker : BackgroundService
    {
        private readonly IConsumerFactory _consumerFactory;
        private readonly IMediator _mediator;
        public ActualizarEntregasWorker(IConsumerFactory consumerFactory, IMediator mediator) {
            _consumerFactory = consumerFactory;
            _mediator = mediator;
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumer = _consumerFactory.GetConsumer();
            consumer.Subscribe("pagos");

            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(cancellationToken);
                //var data = 1;

                // handle consumed message.
                var request = new ActualizarProductoRequest();
                await _mediator.Send(request);
            }

            consumer.Close();

          //  return Task.CompletedTask;
        }
    }
}
