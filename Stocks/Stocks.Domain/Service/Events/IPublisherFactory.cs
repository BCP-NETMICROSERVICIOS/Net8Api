using Confluent.Kafka;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Domain.Service.Events
{
    public interface IPublisherFactory
    {
        IProducer<string, string> GetProducer();
    }
}
