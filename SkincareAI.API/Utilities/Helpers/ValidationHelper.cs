using FluentValidation;

namespace SkincareAI.API.Utilities.Helpers
{
    public static class ValidationHelper
    {
        public static async Task<bool> IsValidAsync<T>(T model, IValidator<T> validator)
        {
            var validationResult = await validator.ValidateAsync(model);
            return validationResult.IsValid;
        }

        public static async Task<List<string>> GetValidationErrorsAsync<T>(T model, IValidator<T> validator)
        {
            var validationResult = await validator.ValidateAsync(model);
            return validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
    }
}