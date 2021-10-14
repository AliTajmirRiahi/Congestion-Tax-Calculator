using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sepehr.Application.OrderHandlers;

namespace Sepehr.Api.Config.ValidatorHandling
{
    public static class ControllerExtension
    {
        public static void AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add(typeof(ValidateModelStateAttribute)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PlaceOrderCommandValidator>())
                .AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });
            
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        }
    }
}