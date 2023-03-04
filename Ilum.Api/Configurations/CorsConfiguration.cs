using System;
namespace Ilum.Api.Configurations;

public static class CorsConfiguration
{
	public static void AddCorsConfiguration(this IServiceCollection services)
	{
		services.AddCors(options => options.AddDefaultPolicy(builder =>
		{
			builder
			.AllowAnyMethod()
			.AllowAnyHeader()
			.SetIsOriginAllowed(origin => true)
			.AllowCredentials();
		}));
	}
}

