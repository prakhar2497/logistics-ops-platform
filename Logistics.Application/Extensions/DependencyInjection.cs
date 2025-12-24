using Logistics.Application.Interface;
using Logistics.Application.Service;
using Logistics.Infrastructure.Interface;
using Logistics.Infrastructure.Repository;
using Logistics.Infrastructure.Security;
using Logistics.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Logistics.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<PasswordHasher>();
            return services;
        }
    }
}
