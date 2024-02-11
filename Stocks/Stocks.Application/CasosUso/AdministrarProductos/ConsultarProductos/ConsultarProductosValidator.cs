using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.CasosUso.AdministrarProductos.ConsultarProductos
{
    public class ConsultarProductosValidator: AbstractValidator<ConsultarProductosRequest>
    {
        public ConsultarProductosValidator()
        {
            RuleFor(item => item.FiltroPorNombre).NotEmpty().WithMessage("Debe especificar un filtro");
        }
    }
}
