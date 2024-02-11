using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Application.CasosUso.AdministrarProductos.RegistrarProducto
{
    public class RegistrarProductoValidator: AbstractValidator<RegistrarProductoRequest>
    {
        public RegistrarProductoValidator()
        {
            RuleFor(item => item.IdProducto).NotEmpty().WithMessage("Debe especificar un Id del producto");
            RuleFor(item => item.Nombre).NotEmpty().WithMessage("Debe indicar el nombre del producto");
            RuleFor(item => item.Stock).NotEmpty().WithMessage("Debe  indicar el Stock");
            RuleFor(item => item.StockMinimo).NotEmpty().WithMessage("Debe  indicar el un Stock mínimo");
            RuleFor(item => item.PrecioUnitario).NotEmpty().WithMessage("Debe  indicar el un precio unitario");
            RuleFor(item => item.IdCategoria).NotEmpty().WithMessage("Debe  indicar Id de la categoria");
        }
    }
}
