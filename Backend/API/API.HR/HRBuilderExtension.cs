﻿using Database.Sql.HR;
using DataBase.Sql.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.HR;
using Service.HR.Interfaces;
using System;

namespace API.HR
{
    public static class HRBuilderExtension
    {
        public static IServiceCollection AddHrServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<HRContext>(options => options.UseSqlServer(config.GetConnectionString("HRConnection")), ServiceLifetime.Scoped);

            services.AddScoped<IHRUnitOfWork, HRUnitOfWork>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<ICommendationService, CommendationService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IApproveStatusService, ApproveStatusService>();
            services.AddScoped<IContractTypeService, ContractTypeService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IIdentificationTypeService, IdentificationTypeService>();
            services.AddScoped<IWardService, WardService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IRankingService, RankingService>();
            services.AddScoped<IProfessionalQualificationService, ProfessionalQualificationService>();
            services.AddScoped<IModelOfStudyService, ModelOfStudyService>();
            return services;
        }
    }
}
