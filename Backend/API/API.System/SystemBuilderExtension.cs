using Core.Services;
using Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.System;
using Services.System.Interfaces;

namespace API.System
{
    public static class SystemBuilderExtension
    {
        public static IServiceCollection AddRoleServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IJwtTokenSecurityService, JwtTokenSecurityService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IFunctionService, FunctionService>();
            return services;
        }
    }
}
