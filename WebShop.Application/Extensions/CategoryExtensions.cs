using WebShop.Application.Dtos;
using WebShop.Domain.Entities;

namespace WebShop.Application.Extensions;

public static class CategoryExtensions
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto(category.Name);
    }
}