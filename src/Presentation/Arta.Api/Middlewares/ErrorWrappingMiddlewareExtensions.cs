using Microsoft.AspNetCore.Builder;

namespace Arta.Api.Middlewares
{
    public static class ErrorWrappingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorWrappingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}