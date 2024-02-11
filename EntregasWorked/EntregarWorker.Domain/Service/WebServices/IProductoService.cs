using EntregarWorker.Domain.Models;
using EntregarWorker.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregarWorker.Domain.Service.WebServices
{
    public interface IProductoService : IRepository
    {
        Task<bool> ActualizarProducto(Producto producto);
    }
}
