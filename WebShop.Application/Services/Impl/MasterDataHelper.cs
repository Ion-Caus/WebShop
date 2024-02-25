using Microsoft.EntityFrameworkCore;
using WebShop.Application.Dtos;
using WebShop.Application.Extensions;
using WebShop.Database.DbContext;

namespace WebShop.Application.Services.Impl;

public class MasterDataHelper(WebShopDbContext context) : IMasterDataHelper
{
    public async Task<IReadOnlyCollection<CategoryDto>> GetCategories()
    {
        var categories = await context.Categories.ToListAsync();
        
        return categories.Select(c => c.ToDto()).ToList();
    }
}