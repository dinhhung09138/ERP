using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess.Sql
{
    /// <summary>
    /// Generic repository class.
    /// </summary>
    /// <typeparam name="T">Class object.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        /// <summary>
        /// Entity model.
        /// </summary>
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Data context.</param>
        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new Exception();
            }

            this._dbSet = context.Set<T>();
        }

        /// <summary>
        /// Check any record.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>true/false.</returns>
        public bool Any(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                return this._dbSet.Any(where);
            }

            return this._dbSet.Any();
        }

        /// <summary>
        /// Check any record. Using asynchonous method.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>true/false.</returns>
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                return await this._dbSet.AnyAsync(where).ConfigureAwait(false);
            }

            return await this._dbSet.AnyAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Count record based on where condition.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>the number of the records.</returns>
        public int Count(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                return this._dbSet.Count(where);
            }

            return this._dbSet.Count();
        }

        /// <summary>
        /// Count record based on where condition. Using asynchonous method.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>the number of the records.</returns>
        public async Task<int> CountAsync(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                return await this._dbSet.CountAsync(where).ConfigureAwait(false);
            }

            return await this._dbSet.CountAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Get the first record based on the condition.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>The first record, return null if don't have any.</returns>
        public T FirstOrDefault(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                IQueryable<T> query = this._dbSet;
                return query.FirstOrDefault(where);
            }

            return this._dbSet.FirstOrDefault();
        }

        /// <summary>
        /// Get the first record based on the condition.
        /// Using asynchonous method.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>The first record, return null if don't have any.</returns>
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                IQueryable<T> query = this._dbSet;
                return await query.FirstOrDefaultAsync(where).ConfigureAwait(false);
            }

            return await this._dbSet.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Build a queryable.
        /// </summary>
        /// <param name="includes">The specified seed value is used as the initial accumulator value.</param>
        /// <returns>IQueryable.</returns>
        public IQueryable<T> Query(string[] includes = null)
        {
            var query = this._dbSet.AsNoTracking();
            if (includes != null && includes.Any())
            {
                query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            }

            return query;
        }

        /// <summary>
        /// Get the a single record based on the condition.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>The single record, return null if don't have any.</returns>
        public T SingleOrDefault(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                IQueryable<T> query = this._dbSet;
                return query.SingleOrDefault(where);
            }

            return this._dbSet.SingleOrDefault();
        }

        /// <summary>
        /// Get the a single record based on the condition.
        /// Using asynchonous method.
        /// </summary>
        /// <param name="where">Where condition.</param>
        /// <returns>The single record, return null if don't have any.</returns>
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                IQueryable<T> query = this._dbSet;
                return await query.SingleOrDefaultAsync(where).ConfigureAwait(false);
            }

            return await this._dbSet.SingleOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
