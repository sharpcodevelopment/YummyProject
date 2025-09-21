using FluentValidation;
using YummyProject.API.Entities.Models;

namespace YummyProject.API.ValidationRules
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation() 
        {
            RuleFor(p=>p.ProductName).NotEmpty().WithMessage("Product name is required.");
            RuleFor(p=>p.ProductName).MaximumLength(25).WithMessage("Product name cannot exceed 25 characters.")
                .MinimumLength(10).WithMessage("Product name must be at least 10 characters.");
            RuleFor(p=>p.Price).NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price cannot exceed 0.")
                .LessThan(1000).WithMessage("Price must be greater than 1000");
        }
    }
}
