namespace WebShop.Application.Dtos;

public record CreateProductStockDto(
    int ProductId,
    int WarehouseId,
    decimal WeightInGrams,
    DateTimeOffset ExpirationDate);