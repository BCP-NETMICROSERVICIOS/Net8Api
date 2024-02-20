using MediatR;
using EntregarWorker.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace EntregarWorker.Application.CasosUso.AdministrarEntregas.RegistrarEntrega
{
    public class RegistrarPedidoRequest : IRequest<IResult>
    {
 
            public object Id { get; set; }
            public int IdVenta { get; set; }
            public string NombreCliente { get; set; }
            public string Direccion { get; set; }
            public string Ciudad { get; set; }
            public virtual IEnumerable<EntregaDetalleRequest> Detalle { get; set; }
        }

        public class EntregaDetalleRequest
        {
            public int IdEntregaDetalle { get; set; }
            public string Producto { get; set; }
            public int Cantidad { get; set; }
        }




    }
