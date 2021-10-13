using Anshan.Framework.Application.Command;
using Microsoft.Extensions.DependencyInjection;

namespace Anshan.Framework.Application
{
    public static class BusExtenstion
    {
        public static void AddBus(this IServiceCollection services)
        {
            services.AddScoped<IBus, Bus>();
            services.AddTransient(typeof(TransactionalCommandHandlerDecorator<>));
            services.AddTransient(typeof(TransactionalCommandHandlerDecorator<,>));
            services.AddTransient(typeof(CommandHandlerDecorator<>));
            services.AddTransient(typeof(CommandHandlerDecorator<,>));
        }
    }
}