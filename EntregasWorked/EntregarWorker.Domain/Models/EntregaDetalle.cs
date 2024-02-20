using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregarWorker.Domain.Models
{
    public class EntregaDetalle
    {

        public int IdEntregaDetalle { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }


    }
}
