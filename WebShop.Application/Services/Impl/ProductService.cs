using Microsoft.EntityFrameworkCore;
using WebShop.Application.Dtos;
using WebShop.Database.DbContext;
using WebShop.Domain.Entities;

namespace WebShop.Application.Services.Impl;

public class ProductService(WebShopDbContext dbContext) : IProductService
{
    public async Task<Product> CreateProduct(CreateProductDto dto)
    {
        var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Name == dto.Category);
        
        if (category is null)
        {
            throw new InvalidOperationException("Category not found");
        }
        
        var product = new Product(
            name: dto.Name,
            description: dto.Description,
            pricePerKg: dto.PricePerKg,
            imageUrl: dto.ImageUrl,
            category: category);
        
        dbContext.Products.Add(product);
        
        await dbContext.SaveChangesAsync();

        return product;
    }
}
