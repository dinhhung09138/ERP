using Core.Services;
using Core.Services.Interfaces;
using Database.Sql.Security;
using Microsoft.EntityFrameworkCore;
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
            //// Declare connect to sql server
            //services.AddDbContext<SecurityContext>(options => options.UseSqlServer(config.GetConnectionString("UserConnection")), ServiceLifetime.Scoped);
            ////Use Data object.
            //services.AddScoped<ISecurityUnitOfWork, SecurityUnitOfWork>();
            //// DI services
            //services.AddScoped<IJwtTokenSecurityService, JwtTokenSecurityService>();
            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
