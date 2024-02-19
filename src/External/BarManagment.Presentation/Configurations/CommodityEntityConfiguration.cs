using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarManagment.Persistance.Configurations
{
    internal class CommodityEntityConfiguration : IEntityTypeConfiguration<Commodity>
    {
        public void Configure(EntityTypeBuilder<Commodity> builder)
        {
            builder.HasKey(commodity => commodity.Id);

            builder.Property(commodity => commodity.Title).IsRequired();

            builder.Property(commodity => commodity.Description).HasDefaultValue(null);

            foreach (var property in builder.Metadata.GetProperties()
           .Where(p => p.ClrType == typeof(decimal)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

            builder.HasOne(commodity => commodity.DefaultMeasure)
                .WithMany()
                .HasForeignKey(commodity => commodity.DefaultMeasureId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
