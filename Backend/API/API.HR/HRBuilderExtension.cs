using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.HR;
using Service.HR.Interfaces;

namespace API.HR
{
    public static class HRBuilderExtension
    {
        public static IServiceCollection AddHrServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IApproveStatusService, ApproveStatusService>();
            services.AddScoped<IPositionService, PositionService>();
            //services.AddScoped<IHRUnitOfWork, HRUnitOfWork>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<ICommendationService, CommendationService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IContractTypeService, ContractTypeService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IIdentificationTypeService, IdentificationTypeService>();
            services.AddScoped<IWardService, WardService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IRankingService, RankingService>();
            services.AddScoped<IProfessionalQualificationService, ProfessionalQualificationService>();
            services.AddScoped<IModelOfStudyService, ModelOfStudyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeInfoService, EmployeeInfoService>();
            services.AddScoped<IEmployeeWorkingStatusService, EmployeeWorkingStatusService>();
            services.AddScoped<IRelationshipTypeService, RelationShipTypeService>();
            services.AddScoped<INationService, NationService>();
            services.AddScoped<INationalityService, NationalityService>();
            services.AddScoped<IReligionService, ReligionService>();
            return services;
        }
    }
}
