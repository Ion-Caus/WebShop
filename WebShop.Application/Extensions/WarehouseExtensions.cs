using WebShop.Application.Dtos;
using WebShop.Domain.Entities;

namespace WebShop.Application.Extensions;

public static class WarehouseExtensions
{
    public static WarehouseDto ToDto(this Warehouse warehouse)
    {
        return new WarehouseDto(warehouse.Id, warehouse.Name);
    }
}