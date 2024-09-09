using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace GymManagementAPI.Extensions
{
    public static class ValidationExtensions
    {
        public static IActionResult ToValidationResponse(this ValidationResult validationResult)
        {
            if (validationResult.IsValid)
            {
                return new OkResult();
            }
            var errors = validationResult.Errors
                                         .Select(e => new { e.PropertyName, e.ErrorMessage })
                                         .ToList();
            return new BadRequestObjectResult(errors);
        }
    }
}
