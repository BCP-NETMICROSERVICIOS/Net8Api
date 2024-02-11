using AutoMapper;
using Pagos.Domain.Models;




namespace Pagos.Application.CasosUso.RegistraPagos
{
    public class RegistrarPagoMapper : Profile
    {
        public RegistrarPagoMapper()
        {
            CreateMap<RegistrarPagoRequest, Pago>();




            // CreateMap<RegistrarPagoRequest, Pago>()

            //.ForMember(dest => dest.IdPago, opt => opt.MapFrom(src => src.Tarjetas));

            // CreateMap<RegistrarPagoDetalleRequest, Tarjeta>();
        }
    }
}
