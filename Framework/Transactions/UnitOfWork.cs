
using Framework.Objects;
using Framework.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Transactions;
public class UnitOfWork : Disposable, IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<string, Tuple<IRepository, object>> _repositories;

    public UnitOfWork(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _repositories = new Dictionary<string, Tuple<IRepository,object>>();
    }

    protected override void Dispose(bool disposing)
    {
        if (!Disposed && disposing)
        {
            foreach (var repository in _repositories)
            {
                repository.Value.Item1.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    public async Task SaveChanges(CancellationToken cancellationToken = default)
    {
        foreach (var repository in _repositories)
        {
            await repository.Value.Item1.SaveChanges(cancellationToken);
        }
    }
    public IRepository<T> GetRepository<T>() where T : class
    {
        var typeName = typeof(T).FullName;
        if (_repositories.TryGetValue(typeName!, out var repository))
        {
            return (IRepository<T>)repository.Item2;
        }

        var obj = _serviceProvider.GetService<IRepository<T>>();
        _repositories.Add(typeName, new Tuple<IRepository, object>(obj, obj));
        return obj;
    }

    public ITransaction BeginTransaction()
    {
        var trans = new UnitOfWorkDbTransaction(_repositories.Select(c => c.Value.Item1));
        return new UnitOfWorkAtomicTransaction(trans);
    }
}