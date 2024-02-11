using Confluent.Kafka;
using Pagos.Domain.Service.Events;

namespace Pagos.Infrastructure.Services.Events
{
    public class EventSender : IEventSender
    {
        private readonly IPublisherFactory _publisherProducer;

        public EventSender(IPublisherFactory publisherProducer)
        {

            _publisherProducer = publisherProducer;
        }

        public async Task PublishAsync(string topic, string serializedMessage, CancellationToken cancellationToken)
        {
            var producer = _publisherProducer.GetProducer();

            await producer.ProduceAsync(
                topic.ToLower(),
                new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = serializedMessage },
                cancellationToken).ConfigureAwait(false);
        }
    }
}
