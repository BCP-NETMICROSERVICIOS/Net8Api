using AutoMapper;
using MediatR;
using Pagos.Application.Common;
using Pagos.Domain.Models;
using Pagos.Domain.Repositories;
using Pagos.Domain.Service.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pagos.Application.CasosUso.RegistraPagos
{
    public class RegistrarPagoHandler :
      IRequestHandler<RegistrarPagoRequest, IResult>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;
        private readonly IEventSender _eventSender;

        public RegistrarPagoHandler(IPagoRepository pagoRepository, IMapper mapper  , IEventSender eventSender)
        {
            _pagoRepository = pagoRepository;
            _mapper = mapper;
           _eventSender = eventSender;
        }


        public async Task<IResult> Handle(RegistrarPagoRequest request, CancellationToken cancellationToken)
        {

            IResult response = null;

            try
            {
                var pago = _mapper.Map<Pago>(request);
                var result = await _pagoRepository.Adicionar(pago);
                if (result)
                {

                    //kafka
                    await _eventSender.PublishAsync("pagos", JsonSerializer.Serialize(pago), cancellationToken);
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
