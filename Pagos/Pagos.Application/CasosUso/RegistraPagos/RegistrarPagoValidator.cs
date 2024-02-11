using FluentValidation;

namespace Pagos.Application.CasosUso.RegistraPagos
{
    public class RegistrarPagoValidator : AbstractValidator<RegistrarPagoRequest>
    {
        public RegistrarPagoValidator()
        {
            RuleFor(item => item.IdPago).NotEmpty().WithMessage("Debe indicar Codigo Pago");
            RuleFor(item => item.NumeroTarjeta).NotEmpty().WithMessage("Debe indicar Numero de Tarjeta");
            RuleFor(item => item.NombreTitular).NotEmpty().WithMessage("Debe  indicar Nombre del Titular");
            RuleFor(item => item.cvv).NotEmpty().WithMessage("Debe  indicar el CVV");
            RuleFor(item => item.FormaPago).NotEmpty().WithMessage("Debe  indicar Forma de Pago");
        }
    }
}
