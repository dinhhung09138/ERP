using Core.Services;
using Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Security;
using Service.Security.Interfaces;

namespace API.Security
{
    public static class SecurityBuilderExtension
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration config)
        {
            //// DI services
            services.AddScoped<IJwtTokenSecurityService, JwtTokenSecurityService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
