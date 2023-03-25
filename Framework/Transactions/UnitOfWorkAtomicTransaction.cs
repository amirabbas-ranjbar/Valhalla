namespace Framework.Transactions;

public class UnitOfWorkAtomicTransaction : AtomicDbTransactionBase
{
    public UnitOfWorkAtomicTransaction(object transaction) : base(transaction)
    {
    }
}