using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Domain.Models
{
    public class VentaDetalle
    {
        public int IdVentaDetalle { get; set; }
        public int IdVenta { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal SubTotal
        {
            get
            {
                return Cantidad * Precio;
            }
            private set { }

        }

    


        public virtual Producto Producto { get; set; }

        public virtual Venta Venta { get; set; }

     //   public virtual PagoDetalle PagoDetalle { get; set; }

    }
}
