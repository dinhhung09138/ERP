using Core.DataAccess;
using Database.Sql.ERP.Entities.Common;

namespace Database.Sql.ERP.Entities
{
    public interface ICommonUnitOfWork
    {
        ITableGenericRepository<ProfessionalQualification> ProfessionalQualificationRepository { get; }
        ITableGenericRepository<Province> ProvinceRepository { get; }
        ITableGenericRepository<District> DistrictRepository { get; }
        ITableGenericRepository<Ward> WardRepository { get; }
    }
}
