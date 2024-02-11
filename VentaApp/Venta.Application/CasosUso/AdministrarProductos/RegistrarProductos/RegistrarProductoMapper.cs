using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Venta.Application.CasosUso.AdministrarVentas.RegistrarVenta;
using Venta.Domain.Models;

namespace Venta.Application.CasosUso.AdministrarProductos.RegistrarProducto
{ 
    public class RegistrarProductoMapper : Profile
    {
        public RegistrarProductoMapper()
        {


            CreateMap<RegistrarProductoRequest, Producto>();
                
                 //   .ForMember(dest => dest.Detalle, map => map.MapFrom(src => src.Productos));

                  //CreateMap<RegistrarVentaDetalleRequest, Models.VentaDetalle>();



                  //CreateMap<Producto, ConsultaProducto>()
                  //    .ForMember(dest=>dest.CodigoProducto, opt=>opt.MapFrom(src=>src.IdProducto));
        }
    }
}
