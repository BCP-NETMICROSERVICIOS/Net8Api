using EntregarWorker.Domain.Models;
using EntregarWorker.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregarWorker.Domain.Service.WebServices
{
    public interface IPagoService : IRepository
    {
        Task<bool> EntregaPedido (Entrega entrega);
    }
}
