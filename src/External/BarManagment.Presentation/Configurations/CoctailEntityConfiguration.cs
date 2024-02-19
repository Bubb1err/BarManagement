using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarManagment.Persistance.Configurations
{
    internal sealed class CoctailEntityConfiguration : IEntityTypeConfiguration<Coctail>
    {
        public void Configure(EntityTypeBuilder<Coctail> builder)
        {
            builder.HasKey(coctail => coctail.Id);

            builder.Property(coctail => coctail.Name).IsRequired();

            builder.Property(coctail => coctail.Description).IsRequired();

            foreach (var property in builder.Metadata.GetProperties()
            .Where(p => p.ClrType == typeof(decimal)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

            builder.HasMany(coctail => coctail.Ingredients).WithOne().OnDelete(DeleteBehavior.Cascade);

        }
    }
}
