using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorApp.Application.Contracts.Persistence;
using RazorApp.Application.Contracts.Persistence.Auth;
using RazorApp.Application.Contracts.Persistence.Common;
using RazorApp.Domain;
using RazorApp.Persistence.Repositories;
using RazorApp.Persistence.Repositories.Auth;
using RazorApp.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorApp.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RazorAppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("RazorAppConnectionString"));
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<RazorAppDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ILoginHelperSessionRepository, LoginHelperSessionRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;

        }
    }
}
