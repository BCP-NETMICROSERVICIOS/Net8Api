using MediatR;

using Venta.Application.Common;

namespace Venta.Application.CasosUso.AdministrarPagos.RegistrarPago
{
    public class RegistrarPagoRequest : IRequest<IResult>
    {

       
        public int IdVenta { get; set; }
        public IEnumerable<RegistrarPagoDetalleRequest> Pagos { get; set; }

    }

    public class RegistrarPagoDetalleRequest
    {
        public int IdPago { get; set; }

       public string Fecha { get; set; }

        public decimal Monto { get; set; }
        public int FormaPago { get; set; }
        public string NumeroTarjeta { get; set; }

        public string FechaVencimiento { get; set; }

        public string CVV { get; set; }

        public string NombreTitular { get; set; }

        public int NumeroCuotas { get; set; }


    }

}
