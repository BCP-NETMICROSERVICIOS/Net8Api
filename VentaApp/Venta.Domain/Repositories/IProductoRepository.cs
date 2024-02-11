using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Domain.Models;

namespace Venta.Domain.Repositories
{
    public  interface IProductoRepository: IRepository
    {
        Task<bool> Adicionar(Producto entity);

        //Task<bool> Modificar(Producto entity);

        Task<bool> Actualizar(Producto entity);

        Task<bool> Eliminar(Producto entity);

        Task<Producto> Consultar(int id);

        Task<IEnumerable<Producto>> Consultar(string nombre);


    }
}
