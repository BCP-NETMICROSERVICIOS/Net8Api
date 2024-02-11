using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntregarWorker.Application.CasosUso.AdministrarProductos.ActualizarProductos;

namespace EntregarWorker.Application.CasosUso.AdministrarProductos.ActualizarProductos
{
    public class RegistrarPedidoValidator : AbstractValidator<ActualizarProductoRequest>
    {
        public RegistrarPedidoValidator()
        {
            RuleFor(item => item.Nombre).NotEmpty().WithMessage("Debe especificar un nombre");
            RuleFor(item => item.Stock).NotEmpty().WithMessage("Debe especificar un Stock");
            RuleFor(item => item.PrecioUnitario).NotEmpty().WithMessage("Debe especificar un precio unitario");
        }
    }
}
