using System;
using Ilum.Api.Models;
using Ilum.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilum.Api.Context.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired();

        builder.HasKey(p => p.Id)
            .IsClustered();

        builder.Property(p => p.IsActive)
            .IsRequired();

        builder.Property(p => p.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Login)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.CurrentPassword)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(p => p.LastPassword)
            .HasMaxLength(64);

        builder.HasOne(p => p.Department)
            .WithMany()
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.CreateByUser)
            .WithMany()
            .HasForeignKey(p => p.CreateByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.ModifiedByUser)
            .WithMany()
            .HasForeignKey(p => p.ModifiedByUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

