using FluentValidation;
using SkincareAI.API.Models.Entities;

namespace SkincareAI.API.Utilities.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(x => x.Brand)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 5);

            RuleFor(x => x.ReviewCount)
                .GreaterThanOrEqualTo(0);
        }
    }
}