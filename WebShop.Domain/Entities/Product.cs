using WebShop.Domain.ValueObjects;

namespace WebShop.Domain.Entities;

public class Product
{
    public Product(string name, string description, Price pricePerKg, Image? image, Category category)
    {
        Name = name;
        Description = description;
        PricePerKg = pricePerKg;
        Image = image;
        Category = category;
    }
    
    private Product() { }
    
    public int Id { get; private set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public Price PricePerKg { get; set; }
    public Image? Image { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}