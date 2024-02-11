using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

using Venta.Application.Common;
using Venta.Domain.Repositories;
using Venta.Domain.Services.WebServices;
using Models = Venta.Domain.Models;

namespace Venta.Application.CasosUso.AdministrarPagos.RegistrarPago
{
    public  class RegistrarPagoHandler:
        IRequestHandler<RegistrarPagoRequest, IResult>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly IPagosService _pagosService;
        private readonly ILogger _logger;

        public RegistrarPagoHandler(IPagoRepository pagoRepository, IProductoRepository productoRepository, IMapper mapper,
            IPagosService pagosService, ILogger<RegistrarPagoHandler> logger )
        {
            _pagoRepository = pagoRepository;
            _productoRepository = productoRepository;
            _mapper = mapper;
            _pagosService = pagosService;
            _logger = logger;
        }

        public async Task<IResult> Handle(RegistrarPagoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IResult response = null;

                //Aplicando el automapper para convertir el objeto Request a venta dominio
                var pagofinal = _mapper.Map<Models.Pago>(request);

               // _logger.LogInformation($"Cantidad de productos {venta.Detalle.Count()}");


                 foreach (var pagodetalle in pagofinal.PagoDetalle)
                 {
                     
                    await _pagosService.ActualizarPagos(pagodetalle.IdPago, pagodetalle.Fecha, pagodetalle.Monto, pagodetalle.FormaPago, pagodetalle.NumeroTarjeta, pagodetalle.FechaVencimiento, pagodetalle.CVV, pagodetalle.NombreTitular, pagodetalle.NumeroCuotas);

               }

                /// Registrar la venta
                /// 
                await _pagoRepository.Adicionar(pagofinal);

                response = new SuccessResult<int>(pagofinal.IdVenta);

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
