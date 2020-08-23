using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.System;
using Services.System.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.System
{
    public static class SystemBuilderExtension
    {
        public static IServiceCollection AddRoleServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IRoleService, RoleService>();
            return services;
        }
    }
}
