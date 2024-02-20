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
        Task<bool> ActualizarPagos(int idpago, int idventa, string fecha, decimal monto, int formapago, string numerotarjeta, string fechavencimiento, string cvv, string nombretitular, int numerocuotas,
                                    int identrega, string direccionentrega, string ciudad);
    }
}
