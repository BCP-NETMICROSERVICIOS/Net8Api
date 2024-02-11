
using VentaWorker.Domain.Service.Events;
using static Confluent.Kafka.ConfigPropertyNames;
using System.Threading;
using MediatR;

using VentaWorker.Application.CasosUso.AdministrarProductos.ActualizarProductos;
 

namespace Venta.Worker.Workers
{
    public class ActualizarStocksWorker : BackgroundService
    {
        private readonly IConsumerFactory _consumerFactory;
        private readonly IMediator _mediator;
        public ActualizarStocksWorker(IConsumerFactory consumerFactory, IMediator mediator) {
            _consumerFactory = consumerFactory;
            _mediator = mediator;
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumer = _consumerFactory.GetConsumer();
            consumer.Subscribe("stocks");

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
