using WebShop.Domain.ValueObjects;

namespace WebShop.Application.Dtos;

public record CreateProductDto(
    Guid ProductId,
    string Name, 
    string Description, 
    Price PricePerKg, 
    string? ImageUrl,
    string Category);
    