using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Domain.Models
{
    public class Entrega
    {


        [Key]
        public int IdEntrega { get; set; }

      //  public int IdPago { get; set; }


        //public int IdVenta { get; set; }
        public string DireccionEntrega { get; set; }

        public string Ciudad { get; set; }

         
      public virtual PagoDetalle PagoDetalle { get; set; }

         


    }
}
