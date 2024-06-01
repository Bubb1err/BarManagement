using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarManagment.Persistance.Configurations
{
    internal class ReceiptEntityConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.HasKey(receipt => receipt.Id);

            builder.Property(receipt => receipt.PaidTime).HasDefaultValue(null);

            builder.Property(receipt => receipt.Created).IsRequired();

            builder.Property(receipt => receipt.IsPaid).HasDefaultValue(false);

            builder.HasMany(receipt => receipt.Coctails)
                .WithMany()
                .UsingEntity(
                    j =>
                {
                    j.IndexerProperty<int>("Id");
                    j.HasKey("Id");
                });

            builder.HasMany(receipt => receipt.Drinks)
                .WithMany()
                .UsingEntity(
                    j =>
                    {
                        j.IndexerProperty<int>("Id");
                        j.HasKey("Id");
                    });

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(receipt => receipt.BarmenId);
        }
    }
}
