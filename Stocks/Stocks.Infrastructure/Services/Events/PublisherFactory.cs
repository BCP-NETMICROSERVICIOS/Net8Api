using Confluent.Kafka;
using Stocks.Domain.Service.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Infrastructure.Services.Events
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
