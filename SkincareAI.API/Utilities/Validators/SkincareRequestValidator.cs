using FluentValidation;
using SkincareAI.API.Models.Requests;

namespace SkincareAI.API.Utilities.Validators
{
    public class SkincareAnalysisRequestValidator : AbstractValidator<SkincareAnalysisRequest>
    {
        public SkincareAnalysisRequestValidator()
        {
            RuleFor(x => x.SkinType)
                .IsInEnum()
                .WithMessage("Invalid skin type");

            RuleFor(x => x.Concerns)
                .NotEmpty()
                .WithMessage("At least one concern is required")
                .Must(concerns => concerns.Count <= 10)
                .WithMessage("Maximum 10 concerns allowed");

            RuleFor(x => x.Symptoms)
                .NotEmpty()
                .WithMessage("At least one symptom is required")
                .Must(symptoms => symptoms.Count <= 15)
                .WithMessage("Maximum 15 symptoms allowed");

            RuleFor(x => x.AdditionalNotes)
                .MaximumLength(500)
                .WithMessage("Additional notes cannot exceed 500 characters");
        }
    }
}