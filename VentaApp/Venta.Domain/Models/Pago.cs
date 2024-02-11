using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Domain.Models
{
    public class Pago
    {




        public int IdVenta { get; set; }

       
        public virtual IEnumerable<PagoDetalle> PagoDetalle { get; set; }
       

    }
}
