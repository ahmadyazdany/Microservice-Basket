using ApplicationService.Repositories;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class BasketRepository : IBasketRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BasketRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(BaseBasket baseBasket, CancellationToken cancellationToken)
    {
        await _dbContext.Baskets.AddAsync(baseBasket, cancellationToken);
    }

    public async Task<BaseBasket?> Load(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Baskets
            .Include(b => b.Items)
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    public async Task<BaseBasket?> LoadByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Baskets
            .Include(b => b.Items)
            .FirstOrDefaultAsync(b => b.UserId == userId, cancellationToken);
    }

    public async Task<BaseBasket?> LoadByUserIdAsNoTracking(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Baskets
            .AsNoTracking()
            .Include(b => b.Items)
            .FirstOrDefaultAsync(b => b.UserId == userId, cancellationToken);
    }
}
