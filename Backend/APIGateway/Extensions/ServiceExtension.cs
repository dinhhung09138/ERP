using APIGateway.Fliters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddFilter(this IServiceCollection services)
        {
            //
            services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.Add<LoggerFilter>();
                options.Filters.Add<ActionFilter>();
                options.Filters.Add<AsyncActionFilter>();
            });

            return services;
        }
    }
}
