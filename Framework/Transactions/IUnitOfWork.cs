using Framework.Repository;

namespace Framework.Transactions;

public interface IUnitOfWork : IDisposable
{
    Task SaveChanges(CancellationToken cancellationToken = default);
    IRepository<T> GetRepository<T>() where T : class;
    public ITransaction BeginTransaction();
}