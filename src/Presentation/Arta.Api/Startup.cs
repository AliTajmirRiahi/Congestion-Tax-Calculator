using Arta.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arta.Api.Config.Identity;
using Arta.Api.Config.Swagger;
using Arta.Api.Middlewares;
using Arta.Persistence.EF.Contexts;
using Arta.Api.Config.Localization;
using Microsoft.Extensions.Options;

namespace Arta.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            //services.AddCustomControllers();

            services.AddCustomLocalization();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddMemoryCache();
            services.AddCore(Configuration);
            services.AddEfCore(Configuration);
            services.AddIdentity();
            services.AddHttpContextAccessor();

            //services.AddRedisCache(Configuration["RedisConnection"]);

            services.AddCustomSwagger();

            services.AddTransient<CultureProviderMiddleware>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolicy",
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .AllowAnyOrigin()
                            .AllowAnyMethod().SetIsOriginAllowed(p => true);
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseErrorWrappingMiddleware();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ArtaDbContext>();
                context.Database.EnsureCreated();
            }

            app.UseCustomSwagger();

            app.UseRouting();

            app.UseAuthorization();

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseMiddleware<CultureProviderMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
