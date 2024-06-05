using Arta.Application.ConsumerHandlers;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Arta.Api.Config.ValidatorHandling
{
    public static class ControllerExtension
    {
        public static void AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add(typeof(ValidateModelStateAttribute)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateVehicleCommandValidator>());

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        }
    }
}