using FluentValidation;

namespace WebShop.Web.Models;

public class ProductStockForm
{
    public int ProductId { get; set; }
    public decimal WeightInGrams { get; set; }
    public DateTime? ExpirationDate { get; set; } = DateTime.Today;
    public int WarehouseId { get; set; }
}

public class ProductStockFormFluentValidator : AbstractValidator<ProductStockForm>
{
    public ProductStockFormFluentValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("The product should be selected.");
        
        RuleFor(x => x.WeightInGrams)
            .NotEmpty()
            .InclusiveBetween(1m, 5_000m)
            .WithMessage("The weight should be between 1 and 5000 grams.");

        RuleFor(x => x.ExpirationDate)
            .NotEmpty();

        RuleFor(x => x.WarehouseId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("The warehouse should be selected.");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var context = ValidationContext<ProductStockForm>.CreateWithOptions(
            (ProductStockForm) model, 
            x => x.IncludeProperties(propertyName));
        
        var result = await ValidateAsync(context);
        
        return result.IsValid 
            ? Array.Empty<string>() 
            : result.Errors.Select(e => e.ErrorMessage);
    };
}
