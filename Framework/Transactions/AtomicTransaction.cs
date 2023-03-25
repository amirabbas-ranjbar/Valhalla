namespace Framework.Transactions;

public abstract class AtomicTransaction : ITransaction
{
    protected AtomicTransaction() 
    {
    }

    public bool AutoCommit { get; set; }

    public object DbTransaction { get; set; }

    public abstract void Commit();

    public abstract Task CommitAsync(CancellationToken cancellationToken = default);

    public abstract void Rollback();

    public abstract Task RollbackAsync(CancellationToken cancellationToken = default);

    public abstract void Dispose();
}
