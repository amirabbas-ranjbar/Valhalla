using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

namespace Framework.Transactions;

public abstract class AtomicDbTransactionBase : AtomicTransaction
    {
        protected AtomicDbTransactionBase(object transaction)
        {
            DbTransaction = transaction;
        }

        public override void Commit()
        {
            Debug.Assert(DbTransaction != null);

            switch (DbTransaction)
            {
                case IDbTransaction dbTransaction:
                    dbTransaction.Commit();
                    break;
                case IDbContextTransaction dbContextTransaction:
                    dbContextTransaction.Commit();
                    break;
                case ITransaction transaction:
                    transaction.Commit();
                    break;
            }

        }

        public override async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            Debug.Assert(DbTransaction != null);

            switch (DbTransaction)
            {
                case IDbTransaction dbTransaction:
                    dbTransaction.Commit();
                    break;
                case IDbContextTransaction dbContextTransaction:
                    await dbContextTransaction.CommitAsync(cancellationToken);
                    break;
                case ITransaction transaction:
                    await transaction.CommitAsync(cancellationToken);
                    break;
            }
        }

        public override void Rollback()
        {
            Debug.Assert(DbTransaction != null);

            switch (DbTransaction)
            {
                case IDbTransaction dbTransaction:
                    dbTransaction.Rollback();
                    break;
                case IDbContextTransaction dbContextTransaction:
                    dbContextTransaction.Rollback();
                    break;
                case ITransaction transaction:
                    transaction.Rollback();
                    break;
            }
        }

        public override async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            Debug.Assert(DbTransaction != null);

            switch (DbTransaction)
            {
                case IDbTransaction dbTransaction:
                    dbTransaction.Rollback();
                    break;
                case IDbContextTransaction dbContextTransaction:
                    await dbContextTransaction.RollbackAsync(cancellationToken);
                    break;
                case ITransaction transaction:
                    await transaction.RollbackAsync(cancellationToken);
                    break;
            }
        }

        public override void Dispose()
        {
            (DbTransaction as IDisposable)?.Dispose();
            DbTransaction = null;
        }
    }