using Confluent.Kafka;

namespace Pagos.Domain.Service.Events
{
    public interface IPublisherFactory
    {
        IProducer<string, string> GetProducer();
    }
}
