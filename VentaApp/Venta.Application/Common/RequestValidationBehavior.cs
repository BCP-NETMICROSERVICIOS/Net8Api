using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Application.CasosUso.AdministrarProductos.ConsultarProductos;

namespace Venta.Application.Common
{
    public class RequestValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger _logger;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationException> logger)
        {
            _validators = validators;
            _logger = logger;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var failures = _validators
                    .Select(v => v.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Count != 0)
                {
                    var exception = new ValidationException(failures);
                    _logger.LogError(exception, failures.ToString());
                    throw exception;                    
                }
            }

            return next();
        }
    }
}
