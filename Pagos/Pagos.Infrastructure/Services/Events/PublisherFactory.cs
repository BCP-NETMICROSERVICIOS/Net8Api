using Confluent.Kafka;
using Pagos.Domain.Service.Events;

namespace Pagos.Infrastructure.Services.Events
{
    public class PublisherFactory : IPublisherFactory
    {
        private static Lazy<IProducer<string, string>> LazyKafkaConnection = null;

        public PublisherFactory(ProducerConfig config)
        {
            LazyKafkaConnection = new Lazy<IProducer<string, string>>(() => new ProducerBuilder<string, string>(config).Build());
        }

        public IProducer<string, string> GetProducer()
            => LazyKafkaConnection.Value;
    }
}
