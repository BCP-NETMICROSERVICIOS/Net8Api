using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stocks.Domain.Models;
using System.Reflection;

namespace Stocks.Application.CasosUso.AdministrarProductos.RegistrarProductos
{
    public class RegistrarProductoMapper: Profile
    {
        public RegistrarProductoMapper()
        {
            CreateMap<RegistrarProductoRequest, Producto>();
            
        }
    }
}
