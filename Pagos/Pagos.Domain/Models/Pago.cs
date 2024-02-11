namespace Pagos.Domain.Models
{
    public class Pago
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

        // public FormaPago FormaPago { get; }
        // public int FormaPago { get; set; }
        //public virtual IEnumerable<Tarjeta> Tarjetas { get; set; }

        //public virtual Cliente Cliente { get; set; }
    }
}
