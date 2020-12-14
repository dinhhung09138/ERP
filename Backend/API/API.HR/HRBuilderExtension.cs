using API.HR.Filters;
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
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IApproveStatusService, ApproveStatusService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<ICommendationService, CommendationService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IContractTypeService, ContractTypeService>();
            services.AddScoped<IIdentificationTypeService, IdentificationTypeService>();
            services.AddScoped<IRankingService, RankingService>();
            services.AddScoped<IModelOfStudyService, ModelOfStudyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeInfoService, EmployeeInfoService>();
            services.AddScoped<IEmployeeEducationService, EmployeeEducationService>();
            services.AddScoped<IEmployeeWorkingStatusService, EmployeeWorkingStatusService>();
            services.AddScoped<IEmployeeBankService, EmployeeBankService>();
            services.AddScoped<IEmployeeIdentificationService, EmployeeIdentificationService>();
            services.AddScoped<IEmployeeContactService, EmployeeContactService>();
            services.AddScoped<IEmployeeCertificateService, EmployeeCertificateService>();
            services.AddScoped<IEmployeeDependencyService, EmployeeDependencyService>();
            services.AddScoped<IEmployeeRelationshipService, EmployeeRelationshipService>();
            services.AddScoped<IRelationshipTypeService, RelationShipTypeService>();
            services.AddScoped<IEthnicityService, EthnicityService>();
            services.AddScoped<INationalityService, NationalityService>();
            services.AddScoped<IReligionService, ReligionService>();
            services.AddScoped<AuthorizationFilterAttribute>();
            return services;
        }
    }
}
