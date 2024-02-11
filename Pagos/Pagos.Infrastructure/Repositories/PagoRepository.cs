using Microsoft.EntityFrameworkCore;
using Pagos.Domain.Models;
using Pagos.Domain.Repositories;
using Pagos.Infrastructure.Repositories.Base;

namespace Pagos.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly PagoDbContext _context;
        public PagoRepository(PagoDbContext context)
        {
            _context = context;
        }


        //public Task<bool> Adicionar(Producto entity)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> Adicionar(Pago entity)
        {


            //_context.Pagos.Add(entity);

            //await _context.SaveChangesAsync(); //INSERT VENTA() VALUES(.....)

            //return entity.IdPago > 0;


            var AddPago = new Pago()
            {
                IdPago = _context.Pagos.Max(id => id.IdPago) + 1,
                IdVentas = entity.IdVentas,
                Fecha = entity.Fecha,
                Monto = entity.Monto,
                FormaPago = entity.FormaPago,
                NumeroTarjeta = entity.NumeroTarjeta,
                FechaVencimiento = entity.FechaVencimiento,
                cvv =entity.cvv,
                NombreTitular = entity.NombreTitular,
                NumeroCuotas = entity.NumeroCuotas
            };


            _context.Pagos.Add(AddPago);
            _context.SaveChanges();
            return entity.IdPago > 0;

        }

        public async Task<Pago> Consultar(int id)
        {

            // return await _context.Productos.FindAsync(id);
            return await _context.Pagos.Where(p => p.IdPago == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Pago>> Consultar(string nombre)
        {
            return await _context.Pagos.Include(p => p.NombreTitular).ToListAsync();
        }



        public async Task<bool> Actualizar(Pago entity)
        {

            throw new NotImplementedException();

            //await _context.Productos.Where(x => x.IdProducto == entity.IdProducto)
            //    .ExecuteUpdateAsync(
            //     s => s.SetProperty(x => x.Nombre, entity.Nombre)
            //    .SetProperty(x => x.Stock, entity.Stock)
            //    .SetProperty(x => x.StockMinimo, entity.StockMinimo)
            //    .SetProperty(x => x.PrecioUnitario, entity.PrecioUnitario)
            //    .SetProperty(x => x.IdCategoria, entity.IdCategoria)

            //);




            //_context.SaveChanges();
            //return true;

        }

        public Task<bool> Eliminar(Pago entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Modificar(Pago entity)
        {
            //return await _context.Up (id);
            throw new NotImplementedException();
        }
    }
}
