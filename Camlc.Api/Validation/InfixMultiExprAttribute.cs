using System.ComponentModel.DataAnnotations;

namespace Lepecki.Playground.Camlc.Api.Validation
{
    public class InfixMultiExprAttribute : InfixExprAttributeBase
    {
        protected override ValidationResult ValidateInfixExpr(object value)
        {
            if (value is string[] exprArray)
            {
                foreach (string expr in exprArray)
                {
                    if (string.IsNullOrEmpty(expr))
                    {
                        return new ValidationResult("Empty expr found");
                    }

                    if (!HasExpectedLength(expr))
                    {
                        return new ValidationResult("Unrecognized symbol(s) found");
                    }
                }
                
                return ValidationResult.Success;
            }

            return new ValidationResult("Incorrect format");
        }
    }
}
