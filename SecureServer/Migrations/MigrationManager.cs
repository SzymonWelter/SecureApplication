using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.DAO;

namespace SecureServer.Migrations
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host){
            using(var scope = host.Services.CreateScope())
            {
                using(var appContext = scope.ServiceProvider.GetRequiredService<SecureContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
            }

            return host;
        }
    }
}