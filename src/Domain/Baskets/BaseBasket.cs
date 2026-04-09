using Components.Framework.DDD;
using Components.Shared.Exceptions;

namespace Domain.Baskets;

public abstract class BaseBasket : BaseEntity<Guid>
{
    public Guid UserId { get; protected set; }

    public ICollection<BasketItem> Items { get; private set; } = [];


    public abstract void AddItem(BasketItem catalogItem);

    internal void CleanUp()
    {
        Items.Clear();
    }

    internal void DecreaseItemQuantity(Guid id)
    {
        var item = Items.FirstOrDefault(d => d.Id == id);
        if(item is null)
            throw new NotFoundEntityException(nameof(item));

        item.DecreaseQuantity();

        if (item.Quantity == 0)
            Items.Remove(item);
    }

    internal void IncreaseItemQuantity(Guid id)
    {
        var item = Items.FirstOrDefault(d => d.Id == id);
        if (item is null)
            throw new NotFoundEntityException(nameof(item));

        item.IncreaseQuantity();
    }

    internal void Remove(Guid itemId)
    {
        var item = Items.FirstOrDefault(d => d.Id == itemId);
        if (item is null)
            throw new NotFoundEntityException(nameof(item));

        Items.Remove(item);
    }
}
