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

            string[] expr = (string[])value;

            foreach (string e in expr) // TODO: naming
            {
                int expectedLength = AnyToken.Matches(e).Sum(match => match.Length);

                if (e.Length != expectedLength)
                {
                    return new ValidationResult("Unrecognized symbol(s) found");
                }
            }

            return ValidationResult.Success;
        }
    }
}
