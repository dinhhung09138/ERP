using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Common;
using Service.Common.Interfaces;
using System;

namespace API.Common
{
    public static class CommonBuilderExtension
    {
        public static IServiceCollection AddCommonService(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IImageServerService, ImageServerService>();
            services.AddScoped<IProfessionalQualificationService, ProfessionalQualificationService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IWardService, WardService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            return services;
        }
    }
}
