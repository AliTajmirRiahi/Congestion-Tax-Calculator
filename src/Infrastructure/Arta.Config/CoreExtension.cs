﻿using Anshan.Framework.DI;
using Anshan.Framework.Permission;
using Arta.Application.CongestionTaxHandlers;
using Arta.Application.ConsumerHandlers;
using Arta.Persistence.EF.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arta.Config
{
    public static class CoreExtension
    {
        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFramework(configuration["ConnectionStrings:DefaultConnection"]);
            services.AddRepositories<VehicleRepository>();
            //services.AddQueryFacades<OrderQueryFacade>();
            services.AddCommandHandlers<CongestionTaxHandler>();
            //services.AddFacades<UserFacade>();

            services.AddSingleton<CongestionTaxCalculator>();

        }
    }
}