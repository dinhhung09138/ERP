using API.System.Filters;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.System;
using Service.System.Interfaces;

namespace API.System
{
    public static class SystemBuilderExtension
    {
        public static IServiceCollection AddRoleServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IJwtTokenSecurityService, JwtTokenSecurityService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFunctionService, FunctionService>();
            services.AddScoped<AuthorizationFilterAttribute>();
            return services;
        }
    }
}
