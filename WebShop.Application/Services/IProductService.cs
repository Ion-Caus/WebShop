using WebShop.Application.Dtos;
using WebShop.Domain.Entities;

namespace WebShop.Application.Services;

public interface IProductService
{
    Task<Product> CreateProduct(CreateProductDto dto);
}