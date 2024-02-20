  using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = Venta.Domain.Models;

namespace Venta.Application.CasosUso.AdministrarVentas.RegistrarVenta
{
    public class RegistrarVentaMapper: Profile
    {
        public RegistrarVentaMapper() {
            CreateMap<RegistrarVentaRequest, Models.Venta>()
                .ForMember(dest => dest.Detalle, map => map.MapFrom(src => src.Productos))
                .ForMember(dest => dest.PagoDetalles, map => map.MapFrom(src => src.Pedidos))
                .ForMember(dest => dest.Entrega, map => map.MapFrom(src => src.Entregas));

             CreateMap<RegistrarVentaDetalleRequest, Models.VentaDetalle>();

             CreateMap<RegistrarPedidoDetalleRequest, Models.PagoDetalle>();
            

             CreateMap<RegistrarEntregaDetalleRequest, Models.Entrega>();
        }
    }
}
