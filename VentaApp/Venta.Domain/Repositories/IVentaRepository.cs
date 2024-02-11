using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Domain.Repositories
{
    public interface IVentaRepository: IRepository
    {
        Task<bool> Registrar(Models.Venta venta);
    }
}
