using Framework.Repository;

namespace Framework.Transactions;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChanges();
}