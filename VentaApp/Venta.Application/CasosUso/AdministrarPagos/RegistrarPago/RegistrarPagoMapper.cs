  using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = Venta.Domain.Models;

namespace Venta.Application.CasosUso.AdministrarPagos.RegistrarPago
{
    public class RegistrarPagoMapper: Profile
    {
        public RegistrarPagoMapper() {
            CreateMap<RegistrarPagoRequest, Models.Pago>() 
               .ForMember(dest => dest.PagoDetalle, map => map.MapFrom(src => src.Pagos));

            CreateMap<RegistrarPagoDetalleRequest, Models.PagoDetalle>();
        }
    }
}
