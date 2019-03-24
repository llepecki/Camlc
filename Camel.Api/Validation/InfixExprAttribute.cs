using System.ComponentModel.DataAnnotations;

namespace Lepecki.Playground.Camel.Api.Validation
{
    public class InfixExprAttribute : RequiredAttribute
    {
        public InfixExprAttribute()
        {
            ErrorMessage = "Value is required";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult initialValidationResult = base.IsValid(value, validationContext);

            if (initialValidationResult != ValidationResult.Success)
            {
                return initialValidationResult;
            }

            string expr = value as string;

            return ValidationResult.Success;
        }
    }
}
