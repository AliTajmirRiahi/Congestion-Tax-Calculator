using Anshan.Framework.Core;
using Anshan.Framework.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Arta.Persistence.EF.Contexts;

namespace Arta.Config
{
    public static class EfCoreExtenstion
    {
        public static void AddEfCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArtaDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"],
                    sqlServerOptions => sqlServerOptions.CommandTimeout(120)).EnableSensitiveDataLogging());

            services.AddScoped<IUnitOfWork, EfUnitOfWork<ArtaDbContext>>();
        }
    }
}