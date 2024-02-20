using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Domain.Models
{
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioUnitario { get; set; }

        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual IEnumerable<VentaDetalle> VentaDetalles { get; set; }



    }
}
