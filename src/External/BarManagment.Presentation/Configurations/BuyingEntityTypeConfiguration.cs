using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BarManagment.Persistance.Configurations
{
    internal sealed class BuyingEntityTypeConfiguration : IEntityTypeConfiguration<Buying>
    {
        public void Configure(EntityTypeBuilder<Buying> builder)
        {
            builder.HasKey(buying => buying.Id);

            builder.HasOne(buying => buying.Commodity)
                .WithMany()
                .HasForeignKey(buying => buying.CommodityId);

            builder.Property(buying => buying.PurchaseAmount).IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_BuyingPurchaseAmount_GreaterOrEqualZero", "PurchaseAmount >= 0"));

            builder.Property(buying => buying.AvailableAmount).IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_BuyingAvailableAmount_GreaterOrEqualZero", "AvailableAmount >= 0"));

            builder.Property(buying => buying.PurchaseDate).IsRequired();
        }
    }
}
