using AutoMapper;
using Confluent.Kafka;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VentaWorker.Application.Common;
using VentaWorker.Domain.Models;
using VentaWorker.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace VentaWorker.Application.CasosUso.AdministrarProductos.ActualizarProductos
{
    public class ActualizarProductoHandler : IRequestHandler<ActualizarProductoRequest, IResult>
    {
         //private readonly IProductoRepository _productoRepository;
         //private readonly IMapper _mapper;
        //public ActualizarProductoHandler(IProductoRepository productoRepository, IMapper mapper)
        public ActualizarProductoHandler()
        {
             //_productoRepository = productoRepository;
             //_mapper = mapper;
        }
        public   Task<IResult> Handle(ActualizarProductoRequest request, CancellationToken cancellationToken)
        {
              throw new NotImplementedException();
            
            //var  Entity = _mapper.Map<Producto>(request);
            //var newstock =   _productoRepository.Adicionar(Entity);

             

            //var stocksResponse = _mapper.Map<ActualizarProductoResponse>(newstock);

          //  return (IResult)stocksResponse;
            //return;
            //async stocksResponse;

        }


    }
}
