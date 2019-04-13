using Com.Lepecki.Playground.Camlc.Api.Validation;
using NUnit.Framework;

namespace Com.Lepecki.Playground.Camlc.Api.Test.Validation
{
    [TestFixture(TestOf = typeof(InfixExprAttribute))]
    public class InfixExprAttributeTest
    {
        [TestCase(null, ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        public bool InfixExprAttributeShouldCorrectlyValidateExpr(string expr)
        {
            var attribute = new InfixExprAttribute();
            return attribute.IsValid(expr);
        }
    }
}
