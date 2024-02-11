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
    public class PagoRepository : IPagoRepository
    {

        private readonly VentaDbContext _context;
        public PagoRepository(VentaDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Adicionar(Domain.Models.Pago entity)
        {
            //_context.Pagos.Add(pago);

            //await _context.SaveChangesAsync(); //INSERT VENTA() VALUES(.....)

            //return entity.IdVenta>0;

            var AddPago = new Pago()
            {
                IdVenta = entity.IdVenta
                
            };


            _context.Pagos.Add(AddPago);
            _context.SaveChanges();
            return entity.IdVenta > 0;

        }
    }
}
