using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    /// <summary>
    /// Generic Unit of work interface.
    /// </summary>
    public interface IGenericUnitOfWork
    {
        /// <summary>
        /// Begin transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Begin transaction. Using asynchonous method.
        /// </summary>
        /// <returns></returns>
        Task BeginTransactionAsync();

        /// <summary>
        /// Commit transaction.
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Commit transaction. Using asynchonous method.
        /// </summary>
        /// <returns></returns>
        Task CommitTransactionAsync();

        /// <summary>
        /// Rollback transaction.
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Rollback transaction. Using asynchonous method.
        /// </summary>
        /// <returns></returns>
        Task RollbackTransactionAsync();

        /// <summary>
        /// Save change if exists.
        /// </summary>
        /// <returns>1: success, 0: nothing to change, -1: Error.</returns>
        int SaveChanges();

        /// <summary>
        /// Save change if exists. Using asynchonous method.
        /// </summary>
        /// <returns>1: success, 0: nothing to change, -1: Error.</returns>
        Task<int> SaveChangesAsync();
    }
}
