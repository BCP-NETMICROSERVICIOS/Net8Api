using Confluent.Kafka;
using EntregarWorker.Domain.Service.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregarWorker.Infrastructure.Services.Events
{
    public class ConsumerFactory : IConsumerFactory
    {
        private static Lazy<IConsumer<string, string>> LazyKafkaConnection = null;

        public ConsumerFactory(ConsumerConfig config)
        {
            LazyKafkaConnection = new Lazy<IConsumer<string, string>>(() => new ConsumerBuilder<string, string>(config).Build());
         //   LazyKafkaConnection = new Lazy<IConsumer<string, string>>(() => new ConsumerBuilder<string, string>(config).Build());
        }

        public IConsumer<string, string> GetConsumer()
            => LazyKafkaConnection.Value;

       
    }
}
