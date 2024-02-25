using System.Net.Mime;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebShop.Domain.Entities;

namespace WebShop.Database.DbContext;

public class WebShopDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly string _connectionString;
    private readonly bool _useManagedIdentity = false;
    
    public WebShopDbContext(string connectionString, DbContextOptions<WebShopDbContext> options) : base(options)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = new SqlConnection(_connectionString);

        if (_useManagedIdentity)
        {
            connection.AccessToken = new AzureServiceTokenProvider().GetAccessTokenAsync("https://database.windows.net/").Result;
        }
        
        optionsBuilder.UseSqlServer(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Cart>()
        //     .HasMany(c => c.CartItems);
        //
        // modelBuilder.Entity<CartItem>()
        //     .HasOne(ci => ci.Product);
        //
        // modelBuilder.Entity<Order>(table =>
        // {
        //     table.HasMany(o => o.OrderItems);
        //     table.OwnsOne(x => x.TotalAmount, info =>
        //     {
        //         info.Property(p => p.Value).HasColumnName("TotalPrice");
        //         info.Property(p => p.CurrencyCode).HasColumnName("CurrencyCode");
        //     });
        // });
        //
        // modelBuilder.Entity<OrderItem>(table =>
        // {
        //     table.HasOne(oi => oi.Product);
        //
        //     table.OwnsOne(x => x.UnitPrice, info =>
        //     {
        //         info.Property(p => p.Value).HasColumnName("UnitPrice");
        //         info.Property(p => p.CurrencyCode).HasColumnName("CurrencyCode");
        //     });
        // });

        modelBuilder.Entity<Product>(table =>
        {
            table.HasOne(p => p.Category);
            table.HasOne(p => p.Image);
            
            table.OwnsOne(x => x.PricePerKg, info =>
            {
                info.Property(p => p.Value).HasColumnName("PricePerKg");
                info.Property(p => p.CurrencyCode).HasColumnName("CurrencyCode");
            });
        });

        modelBuilder.Entity<ProductStock>()
            .HasOne(ps => ps.Warehouse);
    }
    
    //public DbSet<Cart> Carts { get; set; }
    //public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    //public DbSet<Order> Orders { get; set; }
    //public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Image> Images { get; set; }
    //public DbSet<ProductStock> ProductStocks { get; set; }
    //public DbSet<Warehouse> Warehouses { get; set; }
    
}