using ApplicationService.Interfaces;
using ApplicationService.Repositories;
using Components.Framework.CQRS;
using Components.Framework.Persistence;
using Domain.Baskets;

namespace ApplicationService.Handlers.Authenticated;

public record AddItemCommand(Guid CatalogItemId, string Slug, string Name, decimal Price);

public sealed class AddItemHandler(
    IBasketRepository basketRepository,
    IUserPrinciple userPrinciple,
    IUnitOfWork unitOfWork) : ICommandHandler<AddItemCommand>
{
    public async Task Execute(AddItemCommand command, CancellationToken cancellationToken)
    {
        var userId = userPrinciple.GetUserId();

        var basket = await basketRepository.LoadByUserId(userId, cancellationToken);

        if (basket is null)
        {
            basket = PrimaryBasket.Create(userId);
            await basketRepository.Add(basket, cancellationToken);
        }

        basket.AddItem(BasketItem.New(command.CatalogItemId, command.Slug, command.Name, command.Price));

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
