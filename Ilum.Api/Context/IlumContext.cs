using System;
using System.Reflection.Emit;
using Ilum.Api.Context.Configurations;
using Ilum.Api.Models;
using Ilum.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilum.Api.Context;

public class IlumContext : DbContext, IIlumContext
{
    //private const string CONNECTION_STRING = @"Data Source=127.0.0.1; Initial Catalog=Ilum; User Id=sa; Password=ulkXZe9PKPEpli22SKR0; TrustServerCertificate=True";
    protected readonly IConfiguration _configuration;

    public IlumContext(DbContextOptions<IlumContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Domain.Task.Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        //base.OnModelCreating(modelBuilder);


        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}