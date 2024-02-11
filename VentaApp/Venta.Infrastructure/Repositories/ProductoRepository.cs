using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Domain.Models;
using Venta.Domain.Repositories;
using Venta.Infrastructure.Repositories.Base;

namespace Venta.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly VentaDbContext _context;
        public ProductoRepository(VentaDbContext context)
        {
            _context = context;
        }


        //public Task<bool> Adicionar(Producto entity)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> Adicionar(Producto entity)
        {


            //_context.Productos.Add(entity);

            //await _context.SaveChangesAsync(); //INSERT VENTA() VALUES(.....)

            //return entity.IdProducto > 0;


            var AddProducto = new Producto()
            {
                IdProducto = _context.Productos.Max(id => id.IdProducto) + 1,
                Nombre = entity.Nombre,
                Stock = entity.Stock,
                StockMinimo = entity.StockMinimo,
                PrecioUnitario = entity.PrecioUnitario,
                IdCategoria = entity.IdCategoria
            };


            _context.Productos.Add(AddProducto);
            _context.SaveChanges();
            return entity.IdProducto > 0;

        }

        public async Task<Producto> Consultar(int id)
        {
           
           // return await _context.Productos.FindAsync(id);
            return await _context.Productos.Where(p => p.IdProducto == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Producto>> Consultar(string nombre)
        {
            return await _context.Productos.Include(p=>p.Categoria).ToListAsync();
        }



        public async Task<bool> Actualizar(Producto entity)
        {

            await _context.Productos.Where(x => x.IdProducto == entity.IdProducto)
                .ExecuteUpdateAsync(
                 s => s.SetProperty(x => x.Nombre, entity.Nombre)
                .SetProperty(x => x.Stock, entity.Stock)
                .SetProperty(x => x.StockMinimo, entity.StockMinimo)
                .SetProperty(x => x.PrecioUnitario, entity.PrecioUnitario)
                .SetProperty(x => x.IdCategoria, entity.IdCategoria)

            );




            _context.SaveChanges();
            return true;

        }

        public Task<bool> Eliminar(Producto entity)
        {
            throw new NotImplementedException();
        }

        //public Task<bool> Modificar(Producto entity)
        //{
        //    //return await _context.Up (id);
        //    throw new NotImplementedException();
        //}
    }
}
