using WebShop.Domain.ValueObjects;

namespace WebShop.Application.Dtos
{
    public record ProductDto(
        int Id, 
        string Name, 
        string Description, 
        Price PricePerKg, 
        string? ImageSrc, 
        CategoryDto Category);
}