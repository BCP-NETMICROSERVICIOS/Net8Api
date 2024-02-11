using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Domain.Models;

namespace Venta.Domain.Services.WebServices
{
    public  interface IPagosService
    {
        Task<bool> ActualizarPagos(int idpago, string fecha, decimal monto, int formapago, string numerotarjeta, string fechavencimiento, string cvv, string nombretitular, int numerocuotas);
    }
}
