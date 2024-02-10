using Migr8;
using Serilog;
using WebShop.Database.Migrations;

namespace WebShop.Database;

public static class MigrationsRunner
{
    public static void Run(string connectionString)
    {
        var migrations = Migr8.Migrations.FromAssemblyOf<Schema001_Master>();

        var logger = Log.ForContext(typeof(MigrationsRunner));

        var options = new Options(
            logAction: logger.Information,
            verboseLogAction: logger.Verbose
            );
        
        Migr8.Database.Migrate(connectionString, migrations, options);
    }
}