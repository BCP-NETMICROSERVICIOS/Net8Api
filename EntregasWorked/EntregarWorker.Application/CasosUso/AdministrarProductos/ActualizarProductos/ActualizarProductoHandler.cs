using AutoMapper;
using EntregarWorker.Application.Common;
using EntregarWorker.Domain.Models;
using EntregarWorker.Domain.Service.WebServices;
using MediatR;


namespace EntregarWorker.Application.CasosUso.AdministrarProductos.ActualizarProductos
{
    /* 
         1 - Deberia verificar si el productos
         Si existe , entoces actualizar en la table de producto
         Si no existe, crear un nuevo registro

         */
    public class ActualizarProductoHandler :
       IRequestHandler<ActualizarProductoRequest, IResult>
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;

        public ActualizarProductoHandler(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }


        public async Task<IResult> Handle(ActualizarProductoRequest request, CancellationToken cancellationToken)
        {

            IResult response = null;
            bool result = false;

            try
            {
                var producto = _mapper.Map<Producto>(request);
                await _productoService.ActualizarProducto(producto);

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
