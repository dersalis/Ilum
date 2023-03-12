using System;
using Ilum.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Domain.Context.Configurations;

public static class SeedData
{
	public static void SeedDefaultData(this ModelBuilder modelBuilder)
	{
        modelBuilder.Entity<Department>()
        .HasData(
            new Department
            {
                Id = 1,
                Name = "IT",
                Description = "IT Department",
                IsActive = true,
                CreateDate = DateTime.Now,
            }
        );

        modelBuilder.Entity<User.User>()
            .HasData(
                new User.User
                {
                    Id = 1,
                    FirstName = "Administrator",
                    LastName = "Administrator",
                    Email = "admin@wp.pl",
                    Login = "admin",
                    CurrentPassword = BCrypt.Net.BCrypt.HashPassword("P@$$w0rd"),
                    DepartmentId = 1,
                    IsActive = true,
                    CreateDate = DateTime.Now,
                }
            );
    }
}

