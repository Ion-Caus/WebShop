using WebShop.Application.Dtos;
using WebShop.Domain.Entities;

namespace WebShop.Application.Extensions;

public static class ProductExtensions
{
    public static ProductDto ToDto(this Product product)
    {
        return new ProductDto(
            Id: product.Id,
            Name: product.Name,
            Description: product.Description,
            PricePerKg: product.PricePerKg,
            ImageSrc: GetImageSrc(),
            Category: new CategoryDto(product.Category.Name)
        );

        string? GetImageSrc()
        {
            if (product.Image is null)
            {
                return null;
            }
            var base64 = Convert.ToBase64String(product.Image.Data);
            var format = product.Image.Title.Split('.').Last();
            return $"data:image/{format};base64,{base64}";
        }
    }
}