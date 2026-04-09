using Domain.Baskets;

namespace ApplicationService.Repositories;

public interface IBasketRepository
{
    Task Add(BaseBasket baseBasket, CancellationToken cancellationToken);

    Task<BaseBasket?> Load(Guid id, CancellationToken cancellationToken);
    Task<BaseBasket?> LoadByUserId(Guid userId, CancellationToken cancellationToken);
    Task<BaseBasket?> LoadByUserIdAsNoTracking(Guid userId, CancellationToken cancellationToken) ;
}
