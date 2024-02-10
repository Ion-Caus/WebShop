using WebShop.Domain.ValueObjects;

namespace WebShop.Domain.Entities;

public class Product
{
    public Product(string name, string description, Price pricePerKg, string? imageUrl, Category category)
    {
        Name = name;
        Description = description;
        PricePerKg = pricePerKg;
        ImageUrl = imageUrl;
        Category = category;
    }
    
    private Product() { }

    public Guid ProductId { get; private set; } = Guid.NewGuid();
    
    public int Id { get; private set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public Price PricePerKg { get; set; }
    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}