using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.CasosUso.AdministrarProductos.ConsultarProductos
{
    public class ConsultarProductosResponse
    {
        public IEnumerable<ConsultaProducto> Resultado { get; set; }    
    }

    public class ConsultaProducto
    {
        public int CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioUnitario { get; set; }

        public int IdCategoria { get; set; }
    }
}
