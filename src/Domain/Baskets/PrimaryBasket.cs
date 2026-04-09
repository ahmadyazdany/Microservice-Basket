using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Baskets;

public sealed class PrimaryBasket : BaseBasket
{
    private PrimaryBasket() { }

    public static PrimaryBasket Create(Guid userId)
    {
        return new PrimaryBasket { UserId = userId };
    }


    public void AddItem(Guid catalogItemId, string slug, string name, decimal price)
    {
        var item = Items.FirstOrDefault(d => d.CatalogItemId == catalogItemId);

        if (item is null)
            Items.Add(BasketItem.New(catalogItemId,slug,name,price));
        else
            item.IncreaseQuantity();
    }

    public override void AddItem(BasketItem basketItem)
    {
        AddItem(basketItem.CatalogItemId, basketItem.Slug, basketItem.Name, basketItem.Price);
    }
}
