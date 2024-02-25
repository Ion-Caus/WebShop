using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebShop.Database.DbContext;

namespace WebShop.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddWebShopDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<WebShopDbContext>(p => new WebShopDbContext(connectionString, new DbContextOptions<WebShopDbContext>()));

        return services;
    }
}