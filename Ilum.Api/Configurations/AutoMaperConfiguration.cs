using System;
namespace Ilum.Api.Configurations;

public static class AutoMaperConfiguration
{
    public static void AddAutoMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}

