using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

using Venta.Application.Common;
using Venta.Domain.Models;
using Venta.Domain.Repositories;
using Venta.Domain.Services.WebServices;
using Venta.Infrastructure.Services.WebServices;
using Models = Venta.Domain.Models;

namespace Venta.Application.CasosUso.AdministrarVentas.RegistrarVenta
{
    public  class RegistrarVentaHandler:
        IRequestHandler<RegistrarVentaRequest, IResult>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly IStocksService _stocksService;
        private readonly IPagosService _pagoService;
        private readonly ILogger _logger;

        public RegistrarVentaHandler(IVentaRepository ventaRepository, IProductoRepository productoRepository, IMapper mapper,
            IStocksService stocksService, IPagosService pagosService, ILogger<RegistrarVentaHandler> logger )
        {
            _ventaRepository = ventaRepository;
            _productoRepository = productoRepository;
            _mapper = mapper;
            _stocksService = stocksService;
            _logger = logger;
            _pagoService = pagosService;
        }

        public async Task<IResult> Handle(RegistrarVentaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IResult response = null;

                //Aplicando el automapper para convertir el objeto Request a venta dominio
                var venta = _mapper.Map<Models.Venta>(request);
                //var pago = _mapper.Map<Models.PagoDetalle>(request.Pedidos);
                // var pago = _mapper.Map<Models.PagoDetalle>(request);

                _logger.LogInformation($"Cantidad de productos {venta.Detalle.Count()}");


                foreach (var detalle in venta.Detalle)
                {
                    //1 - Validar si el productos existe
                    var productoEncontrado = await _productoRepository.Consultar(detalle.IdProducto);
                    if (productoEncontrado?.IdProducto <= 0)
                    {
                        throw new Exception($"Producto no encontrado, código {detalle.IdProducto}");
                    }
                    //Actualizar el detalle del pedido con el precio del producto
                    detalle.Precio = productoEncontrado.PrecioUnitario;

                    //2 - Reservar el stock del producto
                    //2.1 --Si sucedio algun erro al reservar el producto , retornar una exepcion
                    await _stocksService.ActualizarStock(detalle.IdProducto, detalle.Cantidad);

                   

                }

            
                /// Registrar la venta
                /// 
                await _ventaRepository.Registrar(venta);

                response = new SuccessResult<int>(venta.IdVenta);

                //2 - Registrr Pago despues de realizar la venta
                foreach (var pago in venta.PagoDetalles)
                {
                    foreach (var entregadetalle in venta.Entrega)
                    {

                        //2 - Registrr Pago

                        await _pagoService.ActualizarPagos
                        (pago.IdPago,
                        venta.IdVenta,
                        venta.Fecha.ToString("dd/mmmm/yyyy"), venta.Monto,
                        pago.FormaPago,
                        pago.NumeroTarjeta,
                        pago.FechaVencimiento,
                        pago.CVV, pago.NombreTitular,
                        pago.NumeroCuotas,
                        entregadetalle.IdEntrega,
                        entregadetalle.DireccionEntrega,
                        entregadetalle.Ciudad);
                    }

                }



                return response;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw ex;
            }
        }
        

    }
}
