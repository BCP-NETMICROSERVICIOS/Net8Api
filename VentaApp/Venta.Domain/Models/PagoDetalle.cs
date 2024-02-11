﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Domain.Models
{
    public class PagoDetalle
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


        //public virtual Venta Venta { get; set; }

    }
}
