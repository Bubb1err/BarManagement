using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarManagment.Presentation.Configurations
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.HasMany(user => user.Schedule)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
