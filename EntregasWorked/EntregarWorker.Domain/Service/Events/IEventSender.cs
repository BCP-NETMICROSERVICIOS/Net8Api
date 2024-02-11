using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregarWorker.Domain.Service.Events
{
    public interface IEventSender
    {
        Task PublishAsync(string topic, string serializedMessage, CancellationToken cancellationToken);
    }
}
