﻿using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarManagment.Persistance.Configurations
{
    internal class BarmenScheduleEntityTypeConfiguration : IEntityTypeConfiguration<BarmenSchedule>
    {
        public void Configure(EntityTypeBuilder<BarmenSchedule> builder)
        {
            builder.HasKey(schedule => schedule.Id);

            builder.Property(schedule => schedule.StartDate).IsRequired();

            builder.Property(schedule => schedule.EndDate).IsRequired();

            builder.HasOne<User>()
                .WithMany(user => user.Schedules)
                .HasForeignKey(schedule => schedule.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
