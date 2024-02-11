using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stocks.Application.Common;
using Stocks.Domain.Repositories;
using Stocks.Domain.Models;
using Stocks.Domain.Service.Events;
using System.Text.Json;

namespace Stocks.Application.CasosUso.AdministrarProductos.RegistrarProductos
{
    public class RegistrarProductoHandler:
        IRequestHandler<RegistrarProductoRequest, IResult>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly IEventSender _eventSender;

        public RegistrarProductoHandler(IProductoRepository productoRepository, IMapper mapper , IEventSender eventSender)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
            _eventSender = eventSender;
        }
       

        public async Task<IResult> Handle(RegistrarProductoRequest request, CancellationToken cancellationToken)
        {

            IResult response = null;

            try
            {
                var producto = _mapper.Map<Producto>(request);
                var result = await _productoRepository.Adicionar(producto);
                if (result)
                 {

                    //kafka
                    await _eventSender.PublishAsync("stocks", JsonSerializer.Serialize(producto), cancellationToken);
                    return new SuccessResult();
                 }
                    else
                        return new FailureResult();
                
            }
            catch(Exception ex)
            {
                response = new FailureResult();
                return response;
            }
        }
    }
}
