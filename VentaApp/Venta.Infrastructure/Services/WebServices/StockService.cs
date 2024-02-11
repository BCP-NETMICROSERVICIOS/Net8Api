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
    public class StockService : IStocksService
    {
        private readonly HttpClient _httpClientStocks;
        public StockService(HttpClient httpClientStocks) {
            _httpClientStocks = httpClientStocks;
        }

        public async Task<bool> ActualizarStock(int idProducto, int cantidad)
        {
            //try
           // {
                using var request = new HttpRequestMessage(HttpMethod.Put, "api/productos/reservar");

                var entidadSerializada = JsonSerializer.Serialize(new { IdProducto = idProducto, Cantidad = cantidad });
                request.Content = new StringContent(entidadSerializada, Encoding.UTF8, MediaTypeNames.Application.Json);

                var response = await _httpClientStocks.SendAsync(request);

                return response.IsSuccessStatusCode;
            }
           // catch(Exception ex)
           // {
           //     return false;
           // }
    
      //  }
    }
}
