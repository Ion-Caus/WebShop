namespace WebShop.Domain.Entities;

public class ProductStock
{
    public ProductStock(DateTimeOffset expirationDate, decimal weightInGrams, Product product, Warehouse warehouse)
    {
        WeightInGrams = weightInGrams;
        ExpirationDate = expirationDate;
        ProductId = product.Id;
        Product = product;
        WarehouseId = warehouse.Id;
        Warehouse = warehouse;
    }
    
    private ProductStock() { }

    public int Id { get; private set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public decimal WeightInGrams { get; set; }
    public DateTimeOffset ExpirationDate { get; set; }
    
    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
}