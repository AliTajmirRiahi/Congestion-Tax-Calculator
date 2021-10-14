using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arta.Api.Config.Localization
{
    public class CustomCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));


            var culture = "fa";

            if (string.IsNullOrEmpty(culture))
            {
                // No values specified for either so no match
                return Task.FromResult((ProviderCultureResult)null);
            }

            var requestCulture = new ProviderCultureResult(culture);

            return Task.FromResult(requestCulture);
        }
    }
}
