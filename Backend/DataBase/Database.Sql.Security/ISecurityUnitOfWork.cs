using Core.DataAccess;
using Database.Sql.Security.Entities;

namespace Database.Sql.Security
{
    public interface ISecurityUnitOfWork : IGenericUnitOfWork
    {
        ITableGenericRepository<User> UserRepository { get; }
        ITableGenericRepository<SessionLog> SessionLogRepository { get; }

    }
}
