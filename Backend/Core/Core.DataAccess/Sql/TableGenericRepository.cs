using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Core.DataAccess.Sql
{
    /// <summary>
    /// Table generic repository class.
    /// </summary>
    /// <typeparam name="T">Object type.</typeparam>
    public class TableGenericRepository<T> : GenericRepository<T>, ITableGenericRepository<T>
        where T : class
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Data context.</param>
        public TableGenericRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Add entity to database.
        /// </summary>
        /// <param name="entity">Entity item.</param>
        public void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        /// <summary>
        /// Add entity to database. Using asynchonous method.
        /// </summary>
        /// <param name="entity">Entity item.</param>
        /// <returns>no return.</returns>
        public async Task AddAsync(T entity)
        {
            await this._dbSet.AddAsync(entity).ConfigureAwait(false);
        }

        /// <summary>
        /// Add list of entity to database.
        /// </summary>
        /// <param name="entity">List of entity item.</param>
        public void AddRange(T[] entity)
        {
            this._dbSet.AddRange(entity);
        }

        /// <summary>
        /// Add list of entity to database. Using asynchonous method.
        /// </summary>
        /// <param name="entity">List of entity item.</param>
        /// <returns>no return.</returns>
        public async Task AddRangeAsync(T[] entity)
        {
            await this._dbSet.AddRangeAsync(entity).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete entity item.
        /// </summary>
        /// <param name="entity">Entity item.</param>
        public void Delete(T entity)
        {
            this._dbSet.Remove(entity);
        }

        /// <summary>
        /// Delete a list of entity item.
        /// </summary>
        /// <param name="entity">list of entity item.</param>
        public void DeleteRange(T[] entity)
        {
            this._dbSet.RemoveRange(entity);
        }

        /// <summary>
        /// Update entity item.
        /// </summary>
        /// <param name="entity">Entity item.</param>
        public void Update(T entity)
        {
            this._dbSet.Update(entity);
        }

        /// <summary>
        /// Update list of entity item.
        /// </summary>
        /// <param name="entity">List of entity item.</param>
        public void UpdateRange(T[] entity)
        {
            this._dbSet.UpdateRange(entity);
        }
    }
}
