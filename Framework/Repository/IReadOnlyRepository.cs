using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Framework.Repository;

public interface IReadOnlyRepository<W_DbContext, TEntity, U_PrimaryKey> where W_DbContext : DbContext
    where TEntity : class,
    IDisposable

{
    Task<TEntity> Select(object id);
    Task<IQueryable<TEntity>> Select();
    IQueryable<TEntity> Query();
    Task<IEnumerable<TEntity>> Select(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> FirstOrDefaultAsync();
}