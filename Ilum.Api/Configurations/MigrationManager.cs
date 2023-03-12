using System;
using Ilum.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Configurations;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<IlumContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    //TODO: Log errors or do anything you think it's needed
                    throw;
                }
            }
        }
        return webApp;
    }
}

