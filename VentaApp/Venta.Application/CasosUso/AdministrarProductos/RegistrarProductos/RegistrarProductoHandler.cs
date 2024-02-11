using AutoMapper;
using MediatR;
 
using Venta.Application.Common;
using Venta.Domain.Models;
using Venta.Domain.Repositories;

namespace Venta.Application.CasosUso.AdministrarProductos.RegistrarProducto
{
    public class RegistrarProductoHandler:
        IRequestHandler<RegistrarProductoRequest, IResult>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public RegistrarProductoHandler(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }
       

        public async Task<IResult> Handle(RegistrarProductoRequest request, CancellationToken cancellationToken)
        {

            IResult response = null;
          //  var productofinales = _mapper.Map<Domain.Models.Producto>(request);
            try
            {
                var producto = _mapper.Map<Producto>(request);
                var result = await _productoRepository.Adicionar(producto); ;

                if (result)
                {

                    //kafka
                    //await _eventSender.PublishAsync("stocks", JsonSerializer.Serialize(producto), cancellationToken);
                    return new SuccessResult();
                }
                else
                {
                    return new FailureResult();
                }

            }
            catch(Exception ex)
            {
                response = new FailureResult() ;
                return response;
            }
        }
    }
}
