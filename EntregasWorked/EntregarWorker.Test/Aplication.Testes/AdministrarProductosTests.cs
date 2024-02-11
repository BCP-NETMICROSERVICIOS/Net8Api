using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Application.CasosUso.AdministrarProductos.ConsultarProductos;
using Venta.Domain.Repositories;

namespace Venta.Test.Aplication.Testes
{


    public class AdministrarProductosTests
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly ConsultarProductosHandler _consultarProductosHandler;

        [Fact]
        public async Task ConsultarProductos()
        {

            /// Assert.True(lista.count>0);
        }
    }
}
