using System.ComponentModel.DataAnnotations;

namespace Lepecki.Playground.Camlc.Api.Validation
{
    public class InfixExprAttribute : InfixExprAttributeBase
    {
        protected override ValidationResult ValidateInfixExpr(object value)
        {
            if (value is string expr)
            {
                if (!HasExpectedLength(expr))
                {
                    return new ValidationResult("Unrecognized symbol(s) found");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Incorrect format");
        }
    }
}
