using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarManagment.Persistance.Configurations
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name).IsRequired();

            builder.Property(user => user.Surname).IsRequired();

            builder.Property(user => user.Patronymic).IsRequired();

            builder.Property(user => user.CompanyCode).IsRequired();

            builder.Property(user => user.Email).IsRequired();

            builder.HasMany(user => user.Schedules)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property<string>("_passwordHash")
                    .HasField("_passwordHash")
                    .HasColumnName("PasswordHash")
                    .IsRequired();
        }
    }
}
