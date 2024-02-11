using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Domain.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string DireccionEntrega { get; set; }

        public string Ciudad { get; set; }

        public virtual IEnumerable<Venta> Ventas { get; set; }

       // public virtual IEnumerable<Pago> Pagos { get; set; }



    }
}
