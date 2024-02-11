using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregarWorker.Domain.Models
{
    public class Entrega
    {
        public ObjectId Id { get; set; }

        
        public int IdPago { get; set; }

        public int IdVenta { get; set; }

        public int IdProducto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string Cliente { get; set; }

        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public string DireccionEntrega { get; set; }


        public string Ciudad { get; set; }

        


    }
}
