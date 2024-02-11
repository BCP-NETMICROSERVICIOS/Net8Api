using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Application.Common;

namespace Venta.Application.CasosUso.AdministrarProductos.ConsultarProductos
{
    public class ConsultarProductosRequest: IRequest<IResult>
    {
        public string FiltroPorNombre { get; set; } 
    }
}
