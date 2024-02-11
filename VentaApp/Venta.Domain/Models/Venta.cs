using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Domain.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }

        public int IdCliente { get; set; }

        public DateTime Fecha
        {
            get
            {
                return DateTime.Now;
            }
            private set { }
        }

        public decimal Monto
        {
            get
            {
                return Detalle?.Sum(item => item.SubTotal) ?? 0;
            }
            private set { }
        }

        public virtual Cliente Cliente { get; set; }

        public virtual IEnumerable<VentaDetalle> Detalle { get; set; }

        //public virtual IEnumerable<PagoDetalle> PagoDetalle { get; set; }

        //  public virtual IEnumerable<Pago> Pagos { get; set; }

    }
}
