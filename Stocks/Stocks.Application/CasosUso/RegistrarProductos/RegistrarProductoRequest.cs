using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stocks.Application.Common;

namespace Stocks.Application.CasosUso.AdministrarProductos.RegistrarProductos
{
    public class RegistrarProductoRequest: IRequest<IResult>
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioUnitario { get; set; }

        public int IdCategoria { get; set; }

    }

}
