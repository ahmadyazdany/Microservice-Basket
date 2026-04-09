using Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class BasketConfiguration : IEntityTypeConfiguration<BaseBasket>
{
    public void Configure(EntityTypeBuilder<BaseBasket> builder)
    {
        builder.ToTable(Tables.Baskets, Schemas.Basket)
               .HasKey(b => b.Id);

        builder.Property(b => b.UserId).IsRequired();

        builder.HasDiscriminator<string>("BasketType")
               .HasValue<PrimaryBasket>("Primary")
               .HasValue<SecondaryBasket>("Secondary");


        builder.OwnsMany(b => b.Items,b => {

            b.ToTable(Tables.BasketItems, Schemas.Basket)
             .HasKey(a => a.Id);
            
            b.Property(a => a.Quantity).IsRequired();

            b.Property(d => d.Slug).IsRequired()
                                   .HasMaxLength(100)
                                   .IsUnicode(false);

            b.Property(d => d.Name).IsRequired()
                                   .HasMaxLength(100)
                                   .IsUnicode(true);
        });
    }
}
