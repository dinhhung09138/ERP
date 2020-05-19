using System.Threading.Tasks;

namespace Core.DataAccess
{
    /// <summary>
    /// Table generic repository interface.
    /// </summary>
    /// <typeparam name="T">Class object.</typeparam>
    public interface ITableGenericRepository<T> : IGenericRepository<T>
    {
        /// <summary>
        /// Add list of entity to database.
        /// </summary>
        /// <param name="entity">List of entity item.</param>
        void AddRange(T[] entity);

        /// <summary>
        /// Add list of entity to database. Using asynchonous method.
        /// </summary>
        /// <param name="entity">List of entity item.</param>
        /// <returns>no return.</returns>
        Task AddRangeAsync(T[] entity);

        /// <summary>
        /// Add entity to database.
        /// </summary>
        /// <param name="entity">Entity item.</param>
        void Add(T entity);

        /// <summary>
        /// Add entity to database. Using asynchonous method.
        /// </summary>
        /// <param name="entity">Entity item.</param>
        /// <returns>no return.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Delete entity item.
        /// </summary>
        /// <param name="entity">Entity item.</param>
        void Delete(T entity);

        /// <summary>
        /// Delete a list of entity item.
        /// </summary>
        /// <param name="entity">list of entity item.</param>
        void DeleteRange(T[] entity);

        /// <summary>
        /// Update entity item.
        /// </summary>
        /// <param name="entity">Entity item.</param>
        void Update(T entity);

        /// <summary>
        /// Update list of entity item.
        /// </summary>
        /// <param name="entity">List of entity item.</param>
        void UpdateRange(T[] entity);
    }
}
