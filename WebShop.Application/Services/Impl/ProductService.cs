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
            throw new InvalidOperationException($"Category with name {dto.Category} was not found");
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

    public async Task<ProductStock> AddStock(CreateProductStockDto dto)
    {
        var warehouse = await dbContext.Warehouses.FirstOrDefaultAsync(w => w.Id == dto.WarehouseId);
        if (warehouse is null)
        {
            throw new InvalidOperationException($"Warehouse with id {dto.WarehouseId} was not found.");
        }
        
        var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == dto.ProductId);
        if (product is null)
        {
            throw new InvalidOperationException($"Product with id {dto.ProductId} was not found.");
        }
        
        var productStock = new ProductStock(
            expirationDate: dto.ExpirationDate,
            weightInGrams: dto.WeightInGrams,
            product: product,
            warehouse: warehouse);
        
        dbContext.ProductStocks.Add(productStock);
        
        await dbContext.SaveChangesAsync();
        
        return productStock;
    }

    public async Task<ProductDto?> GetProduct(int id)
    {
        var product = await dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Image)
            .Include(product => product.PricePerKg)
            .FirstOrDefaultAsync(p => p.Id == id);

        return product?.ToDto();
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
