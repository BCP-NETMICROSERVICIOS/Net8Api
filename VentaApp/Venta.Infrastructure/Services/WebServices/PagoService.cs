using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Venta.Domain.Models;
using Venta.Domain.Services.WebServices;

namespace Venta.Infrastructure.Services.WebServices
{
    public class PagoService : IPagosService
    {
        private readonly HttpClient _httpClientPagos;
        public PagoService(HttpClient httpClientPagos) {
            _httpClientPagos = httpClientPagos;
        }

        public async Task<bool> ActualizarPagos(int idpago, string fecha, decimal monto, int formapago, string numerotarjeta, string fechavencimiento, string cvv, string nombretitular, int numerocuotas)
        {
           
                using var request = new HttpRequestMessage(HttpMethod.Put, "api/Pagos/adicionar");

                var entidadSerializada = JsonSerializer.Serialize(new { IdPago = idpago, Fecha = fecha, Monto = monto, FormaPago = formapago, NumeroTarjeta = numerotarjeta, FechaVencimiento = fechavencimiento, CVV = cvv , NombreTitular = nombretitular, NumeroCuotas = numerocuotas });
                request.Content = new StringContent(entidadSerializada, Encoding.UTF8, MediaTypeNames.Application.Json);

                var response = await _httpClientPagos.SendAsync(request);

                return response.IsSuccessStatusCode;
         }
           
    }
}
