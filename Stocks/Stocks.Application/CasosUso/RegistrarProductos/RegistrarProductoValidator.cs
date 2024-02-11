using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.CasosUso.AdministrarProductos.RegistrarProductos
{
    public class RegistrarProductoValidator: AbstractValidator<RegistrarProductoRequest>
    {
        public RegistrarProductoValidator()
        {
            RuleFor(item => item.Nombre).NotEmpty().WithMessage("Debe indicar el nombre del producto");
            RuleFor(item => item.Stock).NotEmpty().WithMessage("Debe  indicar el Stock");
            RuleFor(item => item.StockMinimo).NotEmpty().WithMessage("Debe  indicar el un Stock mínimo");
            RuleFor(item => item.PrecioUnitario).NotEmpty().WithMessage("Debe  indicar el un precio unitario");
        }
    }
}
