using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Application.CasosUso.AdministrarProductos.ActualizarProducto
{

    

    public class ActualizarProductoResponse
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioUnitario { get; set; }

        public int IdCategoria { get; set; }
    }

    
}
