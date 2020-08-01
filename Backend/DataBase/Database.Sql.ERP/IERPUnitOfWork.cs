using Core.DataAccess;
using Database.Sql.ERP.Entities;
using Database.Sql.ERP.Entities.HR;

namespace Database.Sql.ERP
{
    public interface IERPUnitOfWork : IGenericUnitOfWork, ICommonUnitOfWork, IHRUnitOfWork, ITrainingUnitOfWork, ISecurityUnitOfWork
    {
    }
}
