﻿using System;
using System.Reflection.Emit;
using Ilum.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilum.Api.Context;

public class IlumContext : DbContext, IIlumContext
{
    private const string CONNECTION_STRING = @"Data Source=127.0.0.1; Initial Catalog=Ilum; User Id=sa; Password=ulkXZe9PKPEpli22SKR0; TrustServerCertificate=True";

    public IlumContext(DbContextOptions<IlumContext> options) : base(options)
    { }

    public DbSet<Models.Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(CONNECTION_STRING);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
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

    }
}