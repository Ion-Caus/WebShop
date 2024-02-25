using WebShop.Domain.ValueObjects;

namespace WebShop.Application.Dtos;

public record CreateProductDto(
    string Name, 
    string Description, 
    Price PricePerKg, 
    FileDto? Image,
    string Category);
    