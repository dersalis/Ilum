using System;
using Ilum.Domain.Context;

namespace Ilum.Api.Configurations;

public static class DbContextConfiguration
{
	public static void AddDbContextServices(this IServiceCollection services)
	{
		services.AddDbContext<IlumContext>();
    }
}

