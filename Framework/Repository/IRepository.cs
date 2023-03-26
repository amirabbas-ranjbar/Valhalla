using System.Linq.Expressions;
using Framework.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Framework.Repository;

public interface IRepository<W_DbContext, TEntity, U_PrimaryKey>
    where W_DbContext : DbContext
    where TEntity : class
{
    Task<TEntity> Select(U_PrimaryKey id);
    Task<IEnumerable<TEntity>> Select();

    Task<IEnumerable<TEntity>> Select(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

    Task Update(TEntity entity);
    Task Insert(TEntity entity);
    Task InsertRange(IEnumerable<TEntity> entities);
    Task Delete(U_PrimaryKey id);
    Task Delete(TEntity entity);
    Task DeleteRange(IEnumerable<TEntity> entities);
}