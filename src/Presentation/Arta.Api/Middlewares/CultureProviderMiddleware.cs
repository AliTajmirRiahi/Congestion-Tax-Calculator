using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Arta.Api.Middlewares
{

    public class CultureProviderMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var specifiedCulture = new CultureInfo("fa");
            CultureInfo.CurrentUICulture = specifiedCulture;

            await next.Invoke(context);
        }
    }
}
