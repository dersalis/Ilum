using System;
using Ilum.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilum.Domain.Context.Configurations;

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
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
            .HasMaxLength(200);

        //builder.HasOne(p => p.Leader)
        //    .WithMany()
        //    .HasForeignKey(p => p.LeaderId)
        //    .OnDelete(DeleteBehavior.NoAction);
    }
}

