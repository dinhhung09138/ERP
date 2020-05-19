using Core.DataAccess;
using Database.Sql.Security.Entities;

namespace Database.Sql.Security
{
    public interface ISecurityUnitOfWork : IGenericUnitOfWork
    {
        /// <summary>
        /// User table repository.
        /// </summary>
        ITableGenericRepository<User> UserRepository { get; }

        /// <summary>
        /// Session log table repository.
        /// </summary>
        ITableGenericRepository<SessionLog> SessionLogRepository { get; }

    }
}
