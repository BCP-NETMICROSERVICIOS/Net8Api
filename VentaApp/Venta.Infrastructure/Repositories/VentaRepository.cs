using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Domain.Repositories;
using Venta.Infrastructure.Repositories.Base;

namespace Venta.Infrastructure.Repositories
{
    public class VentaRepository : IVentaRepository
    {

        private readonly VentaDbContext _context;
        public VentaRepository(VentaDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Registrar(Domain.Models.Venta venta)
        {
            _context.Ventas.Add(venta);

            await _context.SaveChangesAsync(); //INSERT VENTA() VALUES(.....)

            return venta.IdVenta>0;

        }
    }
}
