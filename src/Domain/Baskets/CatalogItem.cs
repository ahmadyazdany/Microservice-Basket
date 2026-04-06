using Components.Framework.DDD;

namespace Domain.Baskets;

public sealed class CatalogItem : BaseEntity<Guid>
{
    /// <summary>
    /// True Id of Catalog Item Entity in Catalog Module
    /// </summary>
    public Guid CatalogItemId { get; private set; }

    public string Slug { get; private set; }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public decimal? LatestPrice { get; private set; }

    public bool UserChangedSeen { get; private set; }

    public int Quantity { get; private set; }

    public bool PriceChanged => LatestPrice.HasValue &&
                                LatestPrice.Value != Price;

    public static CatalogItem New(Guid catalogItemId, string slug, string name, decimal price)
    {
        return new CatalogItem()
        {
            CatalogItemId = catalogItemId,
            Slug = slug,
            Name = name,
            Price = price,
            Quantity = 1
        };
    }

    public void DecreaseQuantity()
    {
        Quantity--;
    }

    public void IncreaseQuantity()
    {
        Quantity++;
    }

    //public BaseBasket Basket { get; internal set; }
    //public int UserBasketId { get; internal set; }
}
