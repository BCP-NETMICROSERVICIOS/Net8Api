using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Application.CasosUso.AdministrarPagos.RegistrarPago
{
    public  class RegistrarPagoValidator: AbstractValidator<RegistrarPagoRequest>
    {
        public RegistrarPagoValidator() {
            RuleFor(item => item.IdVenta).GreaterThan(0).WithMessage("El cliente tiene que ser mayor que cero");
            RuleFor(item => item.Pagos).Must(item => item?.Count() > 0).WithMessage("Debe tener por lo menos un iten");
        }
    }
}
