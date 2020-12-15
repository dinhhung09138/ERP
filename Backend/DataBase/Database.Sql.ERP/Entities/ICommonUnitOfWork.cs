using Core.DataAccess;
using Database.Sql.ERP.Entities.Common;

namespace Database.Sql.ERP.Entities
{
    public interface ICommonUnitOfWork
    {
        ITableGenericRepository<Certificated> CertificatedRepository { get; }
        ITableGenericRepository<ProfessionalQualification> ProfessionalQualificationRepository { get; }
        ITableGenericRepository<Province> ProvinceRepository { get; }
        ITableGenericRepository<District> DistrictRepository { get; }
        ITableGenericRepository<Major> MajorRepository { get; }
        ITableGenericRepository<School> SchoolRepository { get; }
        ITableGenericRepository<Ward> WardRepository { get; }
        ITableGenericRepository<File> FileRepository { get; }
        ITableGenericRepository<CommonCodeType> CodeTypeRepository { get; }
        ITableGenericRepository<CommonCode> CodeRepository { get; }
        ITableGenericRepository<MaritalStatus> MaritalStatusRepository { get; }
    }
}
