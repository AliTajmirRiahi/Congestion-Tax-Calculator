using Anshan.Framework.DI;
using Anshan.Framework.Permission;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arta.Config
{
    public static class CoreExtension
    {
        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFramework(configuration["ConnectionStrings:DefaultConnection"]);
            //services.AddRepositories<OrderRepository>();
            //services.AddQueryFacades<OrderQueryFacade>();
            //services.AddCommandHandlers<PlaceOrderHandler>();
            //services.AddFacades<UserFacade>();
            
            services.AddScoped<IShop, ShopInfo>();
        }
    }
}