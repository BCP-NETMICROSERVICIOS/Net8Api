using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VentaWorker.Domain.Models;
using VentaWorker.Domain.Repositories;
using VentaWorker.Domain.Service.WebServices;

namespace VentaWorker.Infrastructure.Services.WebServices
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _httpClientProducto;
        public ProductoService(HttpClient httpClientProducto)
        {
            _httpClientProducto = httpClientProducto;
            _httpClientProducto.DefaultRequestHeaders.ProxyAuthorization = null;
        }
        public async Task<bool> ActualizarProducto(Producto producto)
        {
            using var request = new HttpRequestMessage(HttpMethod.Put, "api/productos/actualizar");

             var entidadSerializada = JsonSerializer.Serialize(new { Producto = producto });
            //var entidadSerializada = JsonSerializer.Serialize(new
            //{
            //    IdProducto = producto.IdProducto,
            //    Nombre = producto.Nombre,
            //    Stock = producto.Stock,
            //    StockMinimo = producto.StockMinimo,
            //    PrecioUnitario = producto.PrecioUnitario,
            //    IdCategoria = producto.IdCategoria
            //});
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
