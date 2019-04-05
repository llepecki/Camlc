using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lepecki.Playground.Camlc.Api.Validation
{
    public abstract class InfixExprAttributeBase : RequiredAttribute
    {
        protected static readonly Regex AnyToken = new Regex(@"(ADD|SUB|MUL|DIV|POW|MIN|MAX|NEG|\d+(.\d+)?|\(|\))", RegexOptions.Singleline);

        protected InfixExprAttributeBase()
        {
            ErrorMessage = "Value is required";
        }

        protected abstract ValidationResult ValidateInfixExpr(object value);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult initialValidationResult = base.IsValid(value, validationContext);

            if (initialValidationResult != ValidationResult.Success)
            {
                return initialValidationResult;
            }

            return ValidateInfixExpr(value);
        }

        protected bool HasExpectedLength(string expr)
        {
            int expectedLength = AnyToken.Matches(expr).Sum(match => match.Length);
            return expr.Length == expectedLength;
        }
    }
}
