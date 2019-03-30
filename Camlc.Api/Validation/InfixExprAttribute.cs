using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lepecki.Playground.Camlc.Api.Validation
{
    public class InfixExprAttribute : RequiredAttribute
    {
        private static readonly Regex AnyToken = new Regex(@"(ADD|SUB|MUL|DIV|POW|MIN|MAX|NEG|\d+(.\d+)?|\(|\))", RegexOptions.Singleline);

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

            string expr = (string)value;
            int expectedLength = AnyToken.Matches(expr).Sum(match => match.Length);

            return expr.Length != expectedLength ?
                new ValidationResult("Unrecognized symbol(s) found") :
                ValidationResult.Success;
        }
    }
}
