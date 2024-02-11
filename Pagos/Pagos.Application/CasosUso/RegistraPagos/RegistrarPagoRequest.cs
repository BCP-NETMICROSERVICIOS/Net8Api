using MediatR;
using Pagos.Application.Common;

namespace Pagos.Application.CasosUso.RegistraPagos
{
    public class RegistrarPagoRequest : IRequest<IResult>
    {
        
        public int IdPago { get; set; }
        public int IdVentas { get; set; }
        public string Fecha { get; set; }
        public decimal Monto { get; set; }

        public int FormaPago { get; set; }

        public string NumeroTarjeta { get; set; }

        public string FechaVencimiento { get; set; }
        public string cvv { get; set; }

        public string NombreTitular { get; set; }

        public int NumeroCuotas { get; set; }

    }
}





