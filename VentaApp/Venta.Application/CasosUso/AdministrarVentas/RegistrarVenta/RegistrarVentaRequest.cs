using MediatR;

using Venta.Application.Common;

namespace Venta.Application.CasosUso.AdministrarVentas.RegistrarVenta
{
    public class RegistrarVentaRequest : IRequest<IResult>
    {

        public int IdCliente { get; set; }

        public IEnumerable<RegistrarVentaDetalleRequest> Productos { get; set; }

    }

    public class RegistrarVentaDetalleRequest
    {
        public int IdProducto { get; set; }

        public int Cantidad { get; set; }


    }

}
