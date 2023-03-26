using Microsoft.EntityFrameworkCore;

namespace Framework.Transactions;

public class UnitOfWork<W_DbContext> : IUnitOfWork
    where W_DbContext : DbContext
{
    private readonly W_DbContext _context;

    public UnitOfWork(W_DbContext context)
    {
        _context = context;
    }


    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}