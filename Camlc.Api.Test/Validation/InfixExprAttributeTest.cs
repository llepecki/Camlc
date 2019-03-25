using Lepecki.Playground.Camlc.Api.Validation;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace Lepecki.Playground.Camlc.Api.Test.Validation
{
    [TestFixture]
    public class InfixExprAttributeTest
    {
        [TestCase(null, ExpectedResult = false, TestOf = typeof(InfixExprAttribute))]
        [TestCase("", ExpectedResult = false, TestOf = typeof(InfixExprAttribute))]
        public bool InfixExprAttributeShouldCorrectlyValidateExpr(string expr)
        {
            var attribute = new InfixExprAttribute();
            return attribute.IsValid(expr);
        }
    }
}
