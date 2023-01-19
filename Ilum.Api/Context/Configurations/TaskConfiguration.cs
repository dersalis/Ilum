using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilum.Api.Context.Configurations;

public sealed class TaskConfiguration : IEntityTypeConfiguration<Models.Task>
{
    public void Configure(EntityTypeBuilder<Models.Task> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired();

        builder.HasKey(p => p.Id)
            .IsClustered();

        builder.Property(p => p.IsActive)
            .IsRequired();

        builder.HasOne(p => p.CreateByUser)
            .WithMany()
            .HasForeignKey(p => p.CreateByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.ModifiedByUser)
            .WithMany()
            .HasForeignKey(p => p.ModifiedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Progress);

        builder.Property(p => p.Status)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(p => p.Priority)
            .HasDefaultValue(0)
            .IsRequired();

        builder.HasOne(p => p.ResponsibleUser)
            .WithMany()
            .HasForeignKey(p => p.ResponsibleUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.StartDate);

        builder.Property(p => p.PlannedFinishDate);

        builder.Property(p => p.FinishDate);
    }
}

