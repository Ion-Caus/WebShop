using Microsoft.EntityFrameworkCore;
using WebShop.Application.Dtos;
using WebShop.Application.Extensions;
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
        
        var image = dto.Image is null 
            ? null 
            : new Image(dto.Image.FileName, dto.Image.Data);
        
        if (image is not null)
        {
            dbContext.Images.Add(image);
        }
        
        var product = new Product(
            name: dto.Name,
            description: dto.Description,
            pricePerKg: dto.PricePerKg,
            image: image,
            category: category);
        
        dbContext.Products.Add(product);
        
        await dbContext.SaveChangesAsync();

        return product;
    }

    public async Task<IReadOnlyCollection<ProductDto>> GetProducts()
    {
        var products = await dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Image)
            .Include(product => product.PricePerKg)
            .ToListAsync();

        return products.Select(p => p.ToDto()).ToList();
    }
}
