using Core.DataAccess;
using Database.Sql.ERP.Entities.HR;
namespace Database.Sql.ERP.Entities
{
    public interface IHRUnitOfWork
    {
        ITableGenericRepository<Education> EducationRepository { get; }
        ITableGenericRepository<ApproveStatus> ApproveStatusRepository { get; }
        ITableGenericRepository<Bank> BankRepository { get; }
        ITableGenericRepository<Commendation> CommendationRepository { get; }
        ITableGenericRepository<ContractType> ContractTypeRepository { get; }
        ITableGenericRepository<Discipline> DisciplineRepository { get; }
        ITableGenericRepository<Employee> EmployeeRepository { get; }
        ITableGenericRepository<EmployeeBank> EmployeeBankRepository { get; }
        ITableGenericRepository<EmployeeCommendation> EmployeeCommendationRepository { get; }
        ITableGenericRepository<EmployeeContact> EmployeeContactRepository { get; }
        ITableGenericRepository<EmployeeContract> EmployeeContractRepository { get; }
        ITableGenericRepository<EmployeeContractStatusHistory> EmployeeContractStatusHistoryRepository { get; }
        ITableGenericRepository<EmployeeDiscipline> EmployeeDisciplineRepository { get; }
        ITableGenericRepository<EmployeeDependency> EmployeeDependencyRepository { get; }
        ITableGenericRepository<EmployeeEducation> EmployeeEducationRepository { get; }
        ITableGenericRepository<EmployeeCertificate> EmployeeCertificateRepository { get; }
        ITableGenericRepository<EmployeeIdentification> EmployeeIdentificationRepository { get; }
        ITableGenericRepository<EmployeeInfo> EmployeeInfoRepository { get; }
        ITableGenericRepository<EmployeeRelationship> EmployeeRelationshipRepository { get; }
        ITableGenericRepository<EmployeeLeave> EmployeeLeaveRepository { get; }
        ITableGenericRepository<EmployeeLeaveConfiguration> EmployeeLeaveConfigurationRepository { get; }
        ITableGenericRepository<EmployeeLeaveStatus> EmployeeLeaveStatusRepository { get; }
        ITableGenericRepository<EmployeeWorkingStatus> EmployeeWorkingStatusRepository { get; }
        ITableGenericRepository<IdentificationType> IdentificationTypeRepository { get; }
        ITableGenericRepository<LeaveType> LeaveTypeRepository { get; }
        ITableGenericRepository<LeaveStatus> LeaveStatusRepository { get; }
        ITableGenericRepository<ModelOfStudy> ModelOfStudyRepository { get; }
        ITableGenericRepository<Ethnicity> NationRepository { get; }
        ITableGenericRepository<Nationality> NationalityRepository { get; }
        ITableGenericRepository<Ranking> RankingRepository { get; }
        ITableGenericRepository<RelationshipType> RelationshipTypeRepository { get; }
        ITableGenericRepository<Religion> ReligionRepository { get; }
        ITableGenericRepository<Position> PositionRepository { get; }
    }
}
