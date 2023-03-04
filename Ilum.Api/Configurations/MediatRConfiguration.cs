using System;
using MediatR;
using System.Reflection;

namespace Ilum.Api.Configurations;

public static class MediatRConfiguration
{
	public static void AddMediatRServices(this IServiceCollection services)
	{
		services.AddMediatR(Assembly.GetEntryAssembly());
    }
}

