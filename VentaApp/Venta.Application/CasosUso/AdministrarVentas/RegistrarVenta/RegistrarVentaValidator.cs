using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Application.CasosUso.AdministrarVentas.RegistrarVenta
{
    public  class RegistrarVentaValidator: AbstractValidator<RegistrarVentaRequest>
    {
        public RegistrarVentaValidator() {
            RuleFor(item => item.IdCliente).GreaterThan(0).WithMessage("El cliente tiene que ser mayor que cero");
            RuleFor(item => item.Productos).Must(item => item?.Count() > 0).WithMessage("Debe tener por lo menos un iten");
        }
    }
}
