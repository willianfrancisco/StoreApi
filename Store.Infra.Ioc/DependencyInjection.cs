using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Store.Application.Interfaces;
using Store.Application.Mapping;
using Store.Application.Services;
using Store.Domain.Interfaces;
using Store.Infra.Data.Context;
using Store.Infra.Data.Repository;

namespace Store.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(opt =>
                    opt.UseSqlServer(configuration.GetConnectionString("StoreCs"),
                    b => b.MigrationsAssembly(typeof(StoreContext).Assembly.FullName))
            );

            services.AddAutoMapper(typeof(EntitiesToDtoMapper));

            return services;
        }

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IValidateService, ValidateService>();

            return services;
        }

        public static IServiceCollection AddDependencyInjectionJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(Options =>
                {
                    Options.RequireHttpsMetadata = false;
                    Options.SaveToken = true;
                    Options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["jwt:SecretKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }
            );

            return services;
        }
    }
}