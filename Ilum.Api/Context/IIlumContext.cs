using System;
using Ilum.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Context;

public interface IIlumContext
{
    DbSet<Models.Task> Tasks { get; set; }
	DbSet<User> Users { get; set; }
	DbSet<Department> Departments { get; set; }

	Task<int> SaveChangesAsync();
}