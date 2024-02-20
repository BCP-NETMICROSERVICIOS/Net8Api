using MediatR;

using Venta.Application.Common;

namespace Venta.Application.CasosUso.AdministrarVentas.RegistrarVenta
{
    public class RegistrarVentaRequest : IRequest<IResult>
    {

        public int IdCliente { get; set; }

        public IEnumerable<RegistrarVentaDetalleRequest> Productos { get; set; }


        public IEnumerable<RegistrarPedidoDetalleRequest> Pedidos { get; set; }


        public IEnumerable<RegistrarEntregaDetalleRequest> Entregas { get; set; }

    }

    public class RegistrarVentaDetalleRequest
    {
        public int IdProducto { get; set; }

        public int Cantidad { get; set; }


    }

    public class RegistrarPedidoDetalleRequest
    {
        public int IdPago { get; set; }

        public int FormaPago { get; set; }

        public string NumeroTarjeta { get; set; }

        public string FechaVencimiento { get; set; }
        public string cvv { get; set; }

        public string NombreTitular { get; set; }

        public int NumeroCuotas { get; set; }


    }

    public class RegistrarEntregaDetalleRequest
    {
        public int IdEntrega { get; set; }

        public string DireccionEntrega { get; set; }


        public string Ciudad { get; set; }

       


    }


}
