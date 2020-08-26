using Core.CommonMessage;
using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Core.Utility.Extensions
{
    /// <summary>
    /// Entity extension.
    /// </summary>
    public static class EntityExtension
    {
        /// <summary>
        /// Sort object.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="source">Source query.</param>
        /// <param name="sorts">Sort data.</param>
        /// <returns>IQueryable.</returns>
        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> source, IList<SortModel> sorts)
        {
            IOrderedQueryable<T> result = null;
            var firstSort = sorts.FirstOrDefault(s => !s.IsMultiOrder);
            
            result = SortBy(source, firstSort);

            foreach (var sort in sorts.Where(s => s.IsMultiOrder))
            {
                result = SortBy<T>(result, sort);
            }

            return result;
        }

        /// <summary>
        /// Query sorting.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="source">Source query.</param>
        /// <param name="sort">Sort data.</param>
        /// <returns>IQueryable.</returns>
        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> source, SortModel sort)
        {
            if (sort != null)
            {
                return ApplyOrder<T>(source, sort.Column, sort.LinqDirectionMethod);
            }

            return ApplyOrder<T>(source, null, null);
        }

        /// <summary>
        /// Query ascending ordering.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="source">Source query.</param>
        /// <param name="property">property.</param>
        /// <returns>IQueryable.</returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return ApplyOrder<T>(source, null, null);
            }

            return ApplyOrder<T>(source, property, "OrderBy");
        }

        /// <summary>
        /// Query descending ordering.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="source">Source query.</param>
        /// <param name="property">property.</param>
        /// <returns>IQueryable.</returns>
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return ApplyOrder<T>(source, null, null);
            }

            return ApplyOrder<T>(source, property, "OrderByDescending");
        }

        /// <summary>
        /// query thenby ascending ordering.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="source">Source query.</param>
        /// <param name="property">property.</param>
        /// <returns>IQueryable.</returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return ApplyOrder<T>(source, null, null);
            }

            return ApplyOrder<T>(source, property, "ThenBy");
        }

        /// <summary>
        /// query thenby decending ordering.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="source">Source query.</param>
        /// <param name="property">property.</param>
        /// <returns>IQueryable.</returns>
        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return ApplyOrder<T>(source, null, null);
            }

            return ApplyOrder<T>(source, property, "ThenByDescending");
        }

        /// <summary>
        /// Process list of data based on pagesize and page index.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="source">Source query.</param>
        /// <param name="pageIndex">Current page.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>BaseListModel.</returns>
        public static async Task<BaseListModel<T>> ToBaseList<T>(this IQueryable<T> source, int? pageIndex, int? pageSize)
            where T : class
        {
            var result = new BaseListModel<T>();
            if (source != null || source.Any())
            {
                result.TotalItems = await source.CountAsync().ConfigureAwait(false);

                if (pageIndex.HasValue && pageSize.HasValue && pageSize.Value > 0)
                {
                    var skipCount = (pageIndex.Value - 1) * pageSize.Value;
                    source = source.Skip(skipCount).Take(pageSize.Value);
                }

                result.Items = await source.ToListAsync().ConfigureAwait(false);
            }

            return result;
        }

        /// <summary>
        /// Process list of data based on pagesize and page index.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="source">Source query.</param>
        /// <param name="pageIndex">Current page.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>BaseListModel.</returns>
        public static async Task<BaseListModel<T>> ToBaseListDistinct<T>(this IQueryable<T> source, int pageIndex, int pageSize)
            where T : class
        {
            var result = new BaseListModel<T>();
            if (source != null || source.Any())
            {
                result.TotalItems = await source.CountAsync().ConfigureAwait(false);

                if (pageSize > 0)
                {
                    var skipCount = (pageIndex - 1) * pageSize;
                    source = source.Skip(skipCount).Take(pageSize);
                }

                result.Items = await source.Distinct().ToListAsync().ConfigureAwait(false);
            }

            return result;
        }

        /// <summary>
        /// Process iqueryable ordering.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="source">Source query.</param>
        /// <param name="property">property.</param>
        /// <param name="methodName">Method name.</param>
        /// <returns>IQueryable.</returns>
        private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            if (string.IsNullOrEmpty(property))
            {
                throw new Exception();
            }

            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }

            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }
    }
}
