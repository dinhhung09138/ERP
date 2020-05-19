using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    /// <summary>
    /// Generic repository interface.
    /// </summary>
    /// <typeparam name="T">Class object.</typeparam>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Check any record.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>true/false.</returns>
        bool Any(Expression<Func<T, bool>> where = null);

        /// <summary>
        /// Check any record. Using asynchonous method.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>true/false.</returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> where = null);

        /// <summary>
        /// Count record based on where condition.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>the number of the records.</returns>
        int Count(Expression<Func<T, bool>> where = null);

        /// <summary>
        /// Count record based on where condition. Using asynchonous method.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>the number of the records.</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> where = null);

        /// <summary>
        /// Get the first record based on the condition.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>The first record, return null if don't have any.</returns>
        T FirstOrDefault(Expression<Func<T, bool>> where = null);

        /// <summary>
        /// Get the first record based on the condition.
        /// Using asynchonous method.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>The first record, return null if don't have any.</returns>
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where = null);

        /// <summary>
        /// Build a queryable.
        /// </summary>
        /// <param name="includes">The specified seed value is used as the initial accumulator value.</param>
        /// <returns>IQueryable.</returns>
        IQueryable<T> Query(string[] includes = null);

        /// <summary>
        /// Get the a single record based on the condition.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>The single record, return null if don't have any.</returns>
        T SingleOrDefault(Expression<Func<T, bool>> where = null);

        /// <summary>
        /// Get the a single record based on the condition.
        /// Using asynchonous method.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>The single record, return null if don't have any.</returns>
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where = null);
    }
}
