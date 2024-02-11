using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaWorker.Domain.Models;

namespace VentaWorker.Domain.Repositories
{
    public  interface IProductoRepository: IRepository
    {
        Task<bool> Reponer(Producto entity);

        Task<bool> Actualizar(Producto entity);

        Task<bool> Eliminar(Producto entity);

        Task<Producto> Consultar(int id);

        Task<IEnumerable<Producto>> Consultar(string nombre);


    }
}
