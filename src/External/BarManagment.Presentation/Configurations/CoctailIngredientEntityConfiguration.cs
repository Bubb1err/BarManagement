using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarManagment.Persistance.Configurations
{
    internal class CoctailIngredientEntityConfiguration : IEntityTypeConfiguration<CoctailIngredient>
    {
        public void Configure(EntityTypeBuilder<CoctailIngredient> builder)
        {
            builder.HasKey(ingredient => ingredient.Id);

            builder.HasOne<Commodity>()
                .WithMany()
                .HasForeignKey(ingredient => ingredient.CommodityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(ingredient => ingredient.AmountInDefaultMeasure).IsRequired();

            builder.HasOne<Coctail>()
                .WithMany(coctail => coctail.Ingredients)
                .HasForeignKey(ingredient => ingredient.CoctailId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
