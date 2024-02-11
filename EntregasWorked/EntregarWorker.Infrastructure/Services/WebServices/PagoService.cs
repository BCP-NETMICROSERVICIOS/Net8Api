using Confluent.Kafka;
using EntregarWorker.Domain.Models;
using EntregarWorker.Domain.Service.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EntregarWorker.Infrastructure.Services.WebServices
{
    public class PagoService : IPagoService
    {
        private readonly HttpClient _httpClientProducto;
        public PagoService(HttpClient httpClientProducto)
        {
            _httpClientProducto = httpClientProducto;
            _httpClientProducto.DefaultRequestHeaders.ProxyAuthorization = null;
        }
        public async Task<bool> EntregaPedido (Entrega entrega)
        {
            using var request = new HttpRequestMessage(HttpMethod.Put, "api/pagos/adicionar");

            //var entidadSerializada = JsonSerializer.Serialize(new { Producto = producto });
            var entidadSerializada = JsonSerializer.Serialize(new
            {
                IdPago = entrega.IdPago,
                IdVenta = entrega.IdVenta,
                IdProducto = entrega.IdProducto,
                Fecha = entrega.Fecha,
                Cliente = entrega.Cliente,
                Producto = entrega.Producto,
                Cantidad = entrega.Cantidad,
                DireccionEntrega = entrega.DireccionEntrega,
                Ciudad = entrega.Ciudad
 
            });
            request.Content = new StringContent(entidadSerializada, Encoding.UTF8, MediaTypeNames.Application.Json);


            try
            {
                var response = await _httpClientProducto.SendAsync(request);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
