using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Baskets;

public sealed class PrimaryBasket : BaseBasket
{
    public void AddItem(Guid catalogItemId, string slug, string name, decimal price)
    {
        var item = Items.FirstOrDefault(d => d.CatalogItemId == catalogItemId);

        if (item is null)
            Items.Add(CatalogItem.New(catalogItemId,slug,name,price));
        else
            item.IncreaseQuantity();
    }

    public override void AddItem(CatalogItem catalogItem)
    {
        AddItem(catalogItem.CatalogItemId, catalogItem.Slug, catalogItem.Name, catalogItem.Price);
    }
}
