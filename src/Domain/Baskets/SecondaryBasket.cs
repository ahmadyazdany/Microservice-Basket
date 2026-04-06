using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Domain.Baskets;

public sealed class SecondaryBasket : BaseBasket
{
    public override void AddItem(CatalogItem catalogItem)
    {
        var item = Items.FirstOrDefault(d => d.CatalogItemId == catalogItem.CatalogItemId);

        if (item is null)
            Items.Add(catalogItem);
        else
            item.IncreaseQuantity();
    }
}
