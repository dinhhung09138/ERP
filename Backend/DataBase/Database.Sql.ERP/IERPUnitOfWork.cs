using Core.DataAccess;
using Database.Sql.ERP.Entities;

namespace Database.Sql.ERP
{
    public interface IERPUnitOfWork : IGenericUnitOfWork, ICommonUnitOfWork, IHRUnitOfWork, ITrainingUnitOfWork, ISecurityUnitOfWork
    {
    }
}
