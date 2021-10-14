using Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Arta.Persistence.EF.Contexts;

namespace Arta.Api.Config.Identity
{
    public static class IdentityExtension
    {
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ArtaDbContext>();
        }
    }
}