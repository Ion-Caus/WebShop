using WebShop.Application.Dtos;

namespace WebShop.Application.Services;

public interface IMasterDataHelper
{
    Task<IReadOnlyCollection<CategoryDto>> GetCategories();
}