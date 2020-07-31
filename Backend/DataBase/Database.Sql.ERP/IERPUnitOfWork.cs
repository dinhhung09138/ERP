using Core.DataAccess;
using Database.Sql.ERP.Entities.Common;
using Database.Sql.ERP.Entities.HR;

namespace Database.Sql.ERP
{
    public interface IERPUnitOfWork : IGenericUnitOfWork
    {
        ITableGenericRepository<Education> EducationRepository { get; }
        ITableGenericRepository<ApproveStatus> ApproveStatusRepository { get; }
        ITableGenericRepository<CodeType> CodeTypeRepository { get; }
        ITableGenericRepository<Commendation> CommendationRepository { get; }
        ITableGenericRepository<ContractType> ContractTypeRepository { get; }
        ITableGenericRepository<Discipline> DisciplineRepository { get; }
        ITableGenericRepository<District> DistrictRepository { get; }
        ITableGenericRepository<Employee> EmployeeRepository { get; }
        ITableGenericRepository<EmployeeCommendation> EmployeeCommendationRepository { get; }
        ITableGenericRepository<EmployeeContact> EmployeeContactRepository { get; }
        ITableGenericRepository<EmployeeContract> EmployeeContractRepository { get; }
        ITableGenericRepository<EmployeeContractStatusHistory> EmployeeContractStatusHistoryRepository { get; }
        ITableGenericRepository<EmployeeDiscipline> EmployeeDisciplineRepository { get; }
        ITableGenericRepository<EmployeeEducation> EmployeeEducationRepository { get; }
        ITableGenericRepository<EmployeeIdentification> EmployeeIdentificationRepository { get; }
        ITableGenericRepository<EmployeeInfo> EmployeeInfoRepository { get; }
        ITableGenericRepository<EmployeeRelationship> EmployeeRelationshipRepository { get; }
        ITableGenericRepository<EmployeeWorkingStatus> EmployeeWorkingStatusRepository { get; }
        ITableGenericRepository<IdentificationType> IdentificationTypeRepository { get; }
        ITableGenericRepository<ModelOfStudy> ModelOfStudyRepository { get; }
        ITableGenericRepository<ProfessionalQualification> ProfessionalQualificationRepository { get; }
        ITableGenericRepository<Province> ProvinceRepository { get; }
        ITableGenericRepository<Nation> NationRepository { get; }
        ITableGenericRepository<Nationality> NationalityRepository { get; }
        ITableGenericRepository<Ranking> RankingRepository { get; }
        ITableGenericRepository<RelationshipType> RelationshipTypeRepository { get; }
        ITableGenericRepository<Religion> ReligionRepository { get; }
        ITableGenericRepository<Ward> WardRepository { get; }
    }
}
