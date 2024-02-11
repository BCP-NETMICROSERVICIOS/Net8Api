using AutoMapper;
using MediatR;
 
using Venta.Application.Common;
using Venta.Domain.Models;
using Venta.Domain.Repositories;

namespace Venta.Application.CasosUso.AdministrarProductos.ActualizarProducto
{
    public class ActualizarProductoHandler:
        IRequestHandler<ActualizarProductoRequest, IResult>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ActualizarProductoHandler(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }
       

        public async Task<IResult> Handle(ActualizarProductoRequest request, CancellationToken cancellationToken)
        {

            IResult response = null;
             int id = request.IdProducto;
        
            try
            {
                var producto = _mapper.Map<Producto>(request);
                var result = await _productoRepository.Consultar(id);


                if (result != null)
                {

                    await _productoRepository.Actualizar(producto);

                    response = new SuccessResult<int>();

                    return response;
                }
                else
                {

                    await _productoRepository.Adicionar(producto);

                    response = new SuccessResult<int>();

                    return response;

                }
                
            }
            catch(Exception ex)
            {
                response = new FailureResult();
                return response;
            }
        }
    }
}
