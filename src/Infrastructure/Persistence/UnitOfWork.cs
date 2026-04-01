
using Components.Framework.Persistence;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public int Commit(bool requiredClearChangeTracker = false)
    {
        int result = _context.SaveChanges();
        return result;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken, bool requiredClearChangeTracker = false)
    {
        int result = await _context.SaveChangesAsync();
        return result;
    }
}
