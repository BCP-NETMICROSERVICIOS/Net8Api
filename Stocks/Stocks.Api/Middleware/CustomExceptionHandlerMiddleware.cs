using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using Stocks.Application.Common;

namespace Stocks.Api.Middleware
{

    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;
        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;

                    var requestInvalido = new FailureResult<IEnumerable<DetailError>>
                    {
                        Value = new List<DetailError>()
                    };

                    if (validationException?.Errors.Count() > 0)
                    {
                        foreach (var item in validationException?.Errors)
                        {
                            // foreach (var innerItem in item.)
                            ((List<DetailError>)requestInvalido.Value).Add(new DetailError("ERR_VALIDATION", item.ErrorMessage));
                        }
                    }

                    result = JsonConvert.SerializeObject(requestInvalido, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (string.IsNullOrEmpty(result))
            {
                var requestInvalido = new FailureResult<IEnumerable<DetailError>>
                {
                    Value = new List<DetailError>() { new DetailError("99999", "Error no tratado") }
                };

                result = JsonConvert.SerializeObject(requestInvalido, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }


            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}

