using AutoMapper;
using NSubstitute;
using Pagos.Application.CasosUso.RegistraPagos;
using Pagos.Domain.Models;
using Pagos.Domain.Repositories;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using System.Threading;
using System.Formats.Asn1;


namespace Pagos.Test.AdministrarPagosTest
{
    public class AdministrarPagosTests
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;

        private readonly RegistrarPagoHandler _registrarpagoHandler;

        public IMapper GetMapper()
        {
            var mappingProfile = new RegistrarPagoMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile)).CreateMapper();
            return new Mapper((IConfigurationProvider)configuration);
        }

        public AdministrarPagosTests()
        {

             
          

            

            _pagoRepository = Substitute.For<IPagoRepository>();
            _mapper = GetMapper();
            _registrarpagoHandler = Substitute.For<RegistrarPagoHandler>(_pagoRepository, _mapper);
            // _registrarpagoHandler = Substitute.For<RegistrarPagoHandler>(_pagoRepository, _mapper);



        }

       

        [Fact]
        public async Task RegistrarPedido()
        {
            var request = new RegistrarPagoRequest();
            var mapper = GetMapper();
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var Pagos = new Pago()

            {
                  IdPago = 1,
                  IdVentas = 1,
                  Fecha = "10-02-24",
                  Monto = 110,
                  FormaPago = 1,
                  NumeroTarjeta = "2312513513512",
                  FechaVencimiento = "10-02-24",
                  cvv = "123",
                  NombreTitular = "PRUEBA FGAGDD",
                  NumeroCuotas = 1
               };


          
            _pagoRepository.Adicionar(default).ReturnsForAnyArgs(true);

            var resultado = await _registrarpagoHandler.Handle(request, token);

            Assert.NotNull(resultado);
        }

        


        
    }
}
