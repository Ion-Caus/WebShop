using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;

namespace WebShop.Web.Models;

public class ProductForm
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal PricePerKg { get; set; }
    public string CurrencyCode { get; set; }
    public string Category { get; set; }
    
    public string? ImageName { get; set; }
    public IBrowserFile? Image { get; set; }
}

public class ProductFormFluentValidator : AbstractValidator<ProductForm>
{
    public ProductFormFluentValidator() 
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(min: 10, max: 250);

        RuleFor(x => x.Description)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(50);

        RuleFor(x => x.PricePerKg)
            .NotEmpty()
            .InclusiveBetween(0.01m, 1000m);

        RuleFor(x => x.CurrencyCode)
            .NotEmpty()
            .Length(3);

        RuleFor(x => x.Category)
            .NotEmpty();

        RuleFor(x => x.Image)
            .NotEmpty()
            .WithMessage("The product should have an image.");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var context = ValidationContext<ProductForm>.CreateWithOptions(
            (ProductForm) model, 
            x => x.IncludeProperties(propertyName));
        
        var result = await ValidateAsync(context);
        
        return result.IsValid 
            ? Array.Empty<string>() 
            : result.Errors.Select(e => e.ErrorMessage);
    };
}
