using Framework.Repository;

namespace Framework.Transactions;

public class UnitOfWorkDbTransaction: ITransaction
{
    private readonly IEnumerable<IRepository> _repositories;
    private List<ITransaction> _transactions;
    public UnitOfWorkDbTransaction(IEnumerable<IRepository> repositories)
    {
        _repositories = repositories;
        BeginTransaction();
    }

    private void BeginTransaction()
    {
        _transactions = new List<ITransaction>();
        foreach (var repository in _repositories)
        {
            _transactions.Add(repository.BeginTransaction());
        }
    }
    public void Dispose()
    {
        foreach (var transaction in _transactions)
        {
            transaction.Dispose();
        }
    }

    public bool AutoCommit { get; set; }
    public object DbTransaction { get; set; }

    public void Commit()
    {
        foreach (var transaction in _transactions)
        {
            transaction.Commit();
        }
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        foreach (var transaction in _transactions)
        {
            await transaction.CommitAsync(cancellationToken);
        }
    }

    public void Rollback()
    {
        foreach (var transaction in _transactions)
        {
            transaction.Rollback();
        }
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        foreach (var transaction in _transactions)
        {
            await transaction.RollbackAsync(cancellationToken);
        }
    }

}
