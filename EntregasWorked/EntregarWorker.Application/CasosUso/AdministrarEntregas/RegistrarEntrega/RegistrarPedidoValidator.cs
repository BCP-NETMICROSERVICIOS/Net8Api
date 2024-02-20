using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace EntregarWorker.Application.CasosUso.AdministrarEntregas.RegistrarEntrega
{
    public class RegistrarPedidoValidator : AbstractValidator<RegistrarPedidoRequest>
    {
        public RegistrarPedidoValidator()
        {
            RuleFor(item => item.IdVenta).NotEmpty().WithMessage("Debe especificar el IdVenta");
         //   RuleFor(item => item.Ciudad).NotEmpty().WithMessage("Debe especificar la ciudad de entrega");
        //    RuleFor(item => item.DireccionEntrega).NotEmpty().WithMessage("Debe especificar una Direccion exacta");
        }
    }
}
