namespace WebShop.Domain.Entities;

public class ProductStock
{
    public ProductStock(DateTimeOffset expirationDate, decimal weightKg, Product product, Warehouse warehouse)
    {
        WeightKg = weightKg;
        ExpirationDate = expirationDate;
        Warehouse = warehouse;
    }
    
    private ProductStock() { }

    public int Id { get; private set; }
    
    public int ProductId { get; set; }
    //public Product Product { get; set; } = product;

    public decimal WeightKg { get; set; }
    public DateTimeOffset ExpirationDate { get; set; }
    
    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
}