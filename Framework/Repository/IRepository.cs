using Framework.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Framework.Repository;

public interface IRepository : IDisposable
{
    Task SaveChanges(CancellationToken cancellationToken = default);
    public ITransaction BeginTransaction();
}

public interface IRepository<TEntity> :IRepository where TEntity : class
{
    Task Update(TEntity entity);
    Task Insert(TEntity entity);
    Task InsertRange(IEnumerable<TEntity> entities);
    Task Delete(long id);
    Task Delete(TEntity entity);
    Task DeleteRange(IEnumerable<TEntity> entities);
}