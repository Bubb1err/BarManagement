using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarManagment.Persistance.Configurations
{
    internal sealed class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(role => role.Id);

            builder.Property(role => role.Title).IsRequired();

            builder.HasMany<User>()
                .WithOne(user => user.Role)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
