using System;
using System.Net;
using System.Threading.Tasks;
using Anshan.Framework.Domain.Exceptions;
using Framework.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Arta.Api.Middlewares
{
    public sealed class ErrorHandlingMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            ErrorResponse errorResponse = null;
            HttpStatusCode code = HttpStatusCode.OK;
            switch (exception)
            {
                case RestException re:
                    code = HttpStatusCode.InternalServerError;
                    if (exception is DomainException || exception is CustomApplicationException) code = HttpStatusCode.BadRequest;
                    else
                        code = re.Code;
                    errorResponse = ErrorResponse.Create(re.Errors.ToString(), code);
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    if (exception is DomainException || exception is CustomApplicationException) code = HttpStatusCode.BadRequest;
                    errorResponse = ErrorResponse.Create(exception.Message, code);
                    break;
            }
            var result = JsonConvert.SerializeObject(errorResponse, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;

            return context.Response.WriteAsync(result);
        }
    }
}