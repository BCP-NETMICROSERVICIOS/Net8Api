using FluentMigrator;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Venta.Application.Common;

namespace Venta.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(
            this IServiceCollection services
            )
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddFluentValidation(Assembly.GetExecutingAssembly());

           // services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

              services.AddMediatR(cfg =>
              cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

           // services.AddMediatR(typeof(Assembly).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
          //  services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
        }

        public static IServiceCollection
                AddFluentValidation(this IServiceCollection services, Assembly assembly)
        {

            var validatorType = typeof(IValidator<>);

            var validatorTypes = assembly
                .GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == validatorType))
                .ToList();

            foreach (var validator in validatorTypes)
            {
                var requestType = validator.GetInterfaces()
                    .Where(i => i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IValidator<>))
                    .Select(i => i.GetGenericArguments()[0])
                    .First();

                var validatorInterface = validatorType
                    .MakeGenericType(requestType);

                services.AddTransient(validatorInterface, validator);
            }

            return services;
        }


    }
}
