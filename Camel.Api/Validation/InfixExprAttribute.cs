using System.ComponentModel.DataAnnotations;

namespace Lepecki.Playground.Camel.Api.Validation
{
    public class InfixExprAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var expr = value as string;

            if (expr == null)
            {
                // validation for this case was already done by the Required attribute
                return ValidationResult.Success;
            }
            
            return ValidationResult.Success;
        }
    }
}
