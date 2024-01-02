using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarManagment.Presentation.Configurations
{
    internal class DrinkEntityConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.HasKey(drink => drink.Id);

            builder.Property(drink => drink.Name).IsRequired();

            builder.Property(drink => drink.Description).IsRequired();

            foreach (var property in builder.Metadata.GetProperties()
            .Where(p => p.ClrType == typeof(decimal)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

            builder.Property(drink => drink.AmountInDefaultMeasure).IsRequired();

            builder.HasOne<Commodity>()
                .WithMany()
                .HasForeignKey(drink => drink.CommodityId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
