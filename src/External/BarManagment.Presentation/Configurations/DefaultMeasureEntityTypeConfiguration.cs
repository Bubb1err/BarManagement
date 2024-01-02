using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarManagment.Presentation.Configurations
{
    internal class DefaultMeasureEntityTypeConfiguration : IEntityTypeConfiguration<DefaultMeasure>
    {
        public void Configure(EntityTypeBuilder<DefaultMeasure> builder)
        {
            builder.HasKey(measure => measure.Id);

            builder.Property(measure => measure.Measure).IsRequired();
        }
    }
}
