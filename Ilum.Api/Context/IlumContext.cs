using System;
using Ilum.Api.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}