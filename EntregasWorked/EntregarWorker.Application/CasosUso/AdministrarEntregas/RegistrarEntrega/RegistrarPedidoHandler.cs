using AutoMapper;
using EntregarWorker.Application.Common;
using EntregarWorker.Domain.Models;
using EntregarWorker.Domain.Service.WebServices;
using MediatR;


namespace EntregarWorker.Application.CasosUso.AdministrarEntregas.RegistrarEntrega
{
    /* 
        Pendiente implementar interfaz con ventas, pagos

         */
    public class RegistrarPedidoHandler :
       IRequestHandler<RegistrarPedidoRequest, IResult>
    {
        private readonly IPagoService _pagoService;
        private readonly IMapper _mapper;

        public RegistrarPedidoHandler(IPagoService pagoService, IMapper mapper)
        {
            _pagoService = pagoService;
            _mapper = mapper;
        }


        public async Task<IResult> Handle(RegistrarPedidoRequest request, CancellationToken cancellationToken)
        {

            IResult response = null;
            bool result = false;

            try
            {
                var entregas = _mapper.Map<Entrega>(request);
                await _pagoService.EntregaPedido(entregas);

                if (result)
                {
                    return new SuccessResult();
                }
                else
                    return new FailureResult();

            }
            catch (Exception ex)
            {
                response = new FailureResult();
                return response;
            }
        }
    }
}
