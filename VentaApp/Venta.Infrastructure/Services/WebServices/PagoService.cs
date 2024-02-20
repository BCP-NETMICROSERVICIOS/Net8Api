using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Venta.Domain.Models;
using Venta.Domain.Services.WebServices;
using static System.Net.Mime.MediaTypeNames;

namespace Venta.Infrastructure.Services.WebServices
{
    public class PagoService : IPagosService
    {
        private readonly HttpClient _httpClientPagos;
        public PagoService(HttpClient httpClientPagos) {
            _httpClientPagos = httpClientPagos;
        }

        public async Task<bool> ActualizarPagos(int idpago, int idventa, string fecha, decimal monto, int formapago, string numerotarjeta, string fechavencimiento, string cvv, string nombretitular, int numerocuotas, int identrega, string direccionentrega, string ciudad)
        {

            using var request = new HttpRequestMessage(HttpMethod.Post, "api/Pagos/registrar");

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.WriteIndented = true;
            options.IncludeFields = true;
           



            var entidadSerializada = JsonSerializer.Serialize(new
            { IdPago = idpago, IdVenta = idventa, Fecha = fecha, Monto = monto, FormaPago = formapago, NumeroTarjeta = numerotarjeta, FechaVencimiento = fechavencimiento, CVV = cvv, NombreTitular = nombretitular, NumeroCuotas = numerocuotas,
            Entregas = new[]
             {
             new {identrega, DireccionEntrega = direccionentrega, Ciudad = ciudad }
                 },
            }

            , options);
           // var entidadSerializada = JsonSerializer.Serialize(new { IdPago = idpago, IdVenta = idventa, Fecha = fecha, Monto = monto, FormaPago = formapago, NumeroTarjeta = numerotarjeta, FechaVencimiento = fechavencimiento, CVV = cvv, NombreTitular = nombretitular, NumeroCuotas = numerocuotas, IdEntrega = identrega, DireccionEntrega = direccionentrega, Ciudad = ciudad });

           // var entidadSerializadaentrega = JsonSerializer.Serialize(new { identrega, DireccionEntrega = direccionentrega, Ciudad = ciudad }, options);

           

            request.Content = new StringContent((entidadSerializada), Encoding.UTF8, MediaTypeNames.Application.Json);

                var response = await _httpClientPagos.SendAsync(request);

                return response.IsSuccessStatusCode;
         }
           
    }
}
