using System;
using System.Reflection.Emit;
using Azure.Core;
using Ilum.Domain.Context.Configurations;
using Ilum.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Ilum.Domain.Context;

public class IlumContext : DbContext, IIlumContext
{
    //private const string CONNECTION_STRING = @"Data Source=127.0.0.1; Initial Catalog=Ilum; User Id=sa; Password=ulkXZe9PKPEpli22SKR0; TrustServerCertificate=True";
    protected readonly IConfiguration _configuration;

    public IlumContext(DbContextOptions<IlumContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Domain.Task.Task> Tasks { get; set; }
    public DbSet<User.User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), options => options.MigrationsAssembly("Ilum.Api")); // Migracja do innego projektu
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        modelBuilder.SeedDefaultData();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}