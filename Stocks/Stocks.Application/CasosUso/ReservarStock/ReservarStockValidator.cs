using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.CasosUso.AdministrarProductos.ReservarStock
{
    public class ReservarStockValidator : AbstractValidator<ReservarStockRequest>
    {
        public ReservarStockValidator()
        {
            RuleFor(item => item.IdProducto).GreaterThan(0).WithMessage("Debe especificar el código del producto");
            RuleFor(item => item.Cantidad).GreaterThan(0).WithMessage("La cantidad tiene que ser mayor que cero");
        }
    }
}
