using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Domain.Baskets;

public sealed class SecondaryBasket : BaseBasket
{
    public override void AddItem(BasketItem basketItem)
    {
        var item = Items.FirstOrDefault(d => d.CatalogItemId == basketItem.CatalogItemId);

        if (item is null)
            Items.Add(basketItem);
        else
            item.IncreaseQuantity();
    }
}
