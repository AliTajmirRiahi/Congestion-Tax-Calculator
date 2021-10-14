using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Arta.Api.Middlewares;

namespace Arta.Api.Config.Localization
{
    public static class LocalizationExtension
    {
        public static void AddCustomLocalization(this IServiceCollection services)
        {
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            services.AddMvc().AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = (t, f) => f.Create(typeof(SharedResources)));


            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var suportedCulture = new List<CultureInfo>
                {
                    new CultureInfo("fa"),
                    new CultureInfo("en"),
                    new CultureInfo("ar"),
                };
                opt.DefaultRequestCulture = new RequestCulture("fa");
                opt.SupportedCultures = suportedCulture;
                opt.SupportedUICultures = suportedCulture;
                opt.RequestCultureProviders.Add(new CustomCultureProvider());
            });
        }
    }
}
