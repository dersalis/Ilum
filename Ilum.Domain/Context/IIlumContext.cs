using System;
using Ilum.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Domain.Context;

public interface IIlumContext
{
    DbSet<Domain.Task.Task> Tasks { get; set; }
	DbSet<User.User> Users { get; set; }
	DbSet<Department> Departments { get; set; }

	Task<int> SaveChangesAsync();
}