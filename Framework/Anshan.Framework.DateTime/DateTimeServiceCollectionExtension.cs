using Microsoft.Extensions.DependencyInjection;

namespace Anshan.Framework.DateTime
{
    public static class DateTimeServiceCollectionExtension
    {
        public static IServiceCollection AddDateTimeServices(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}