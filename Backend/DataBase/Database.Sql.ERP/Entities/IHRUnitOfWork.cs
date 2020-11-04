using Core.DataAccess;
using Database.Sql.ERP.Entities.HR;
namespace Database.Sql.ERP.Entities
{
    public interface IHRUnitOfWork
    {
        ITableGenericRepository<Education> EducationRepository { get; }
        ITableGenericRepository<ApproveStatus> ApproveStatusRepository { get; }
        ITableGenericRepository<Commendation> CommendationRepository { get; }
        ITableGenericRepository<ContractType> ContractTypeRepository { get; }
        ITableGenericRepository<Discipline> DisciplineRepository { get; }
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
        ITableGenericRepository<Ethnicity> NationRepository { get; }
        ITableGenericRepository<Nationality> NationalityRepository { get; }
        ITableGenericRepository<Ranking> RankingRepository { get; }
        ITableGenericRepository<RelationshipType> RelationshipTypeRepository { get; }
        ITableGenericRepository<Religion> ReligionRepository { get; }
        ITableGenericRepository<Position> PositionRepository { get; }
    }
}
