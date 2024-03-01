using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CurrencyWebAPI.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TResult> GetFilteredFirstOrDefault<TResult>(
             Expression<Func<TEntity, TResult>> select,
             Expression<Func<TEntity, bool>> where,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
        );

        Task<List<TResult>> GetFilteredList<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            );
        Task<List<TEntity>> GetDefaults(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> GetDefault(Expression<Func<TEntity, bool>> expression);

        Task<bool> Any(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Save New <typeparamref name="TEntity" />
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Add(TEntity entity);

        Task<bool> AddRange(List<TEntity> entities);

        /// <summary>
        /// Update <typeparamref name="TEntity" />
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Update(TEntity entity);

        /// <summary>
        /// Delete <typeparamref name="TEntity" />
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<bool> Delete(TEntity entity);
        Task<bool> DeleteRange(List<TEntity> entity);


        Task<int> Save();
    }
}
