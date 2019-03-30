using Lepecki.Playground.Camlc.Engine.Abstractions;
using NUnit.Framework;

namespace Lepecki.Playground.Camlc.Engine.Test
{
    [TestFixture(TestOf = typeof(YouBastardCalc))]
    public class YouBastardCalcTests
    {
        [TestCase("3MUL4DIV2", ExpectedResult = 6.0000)]
        [TestCase("3ADD4.2MUL5.5DIV6", ExpectedResult = 6.8500)]
        [TestCase("(300ADD23.05)MUL(43.3SUB21)DIV(84ADD7)", ExpectedResult = 79.1650)]
        [TestCase("(4000.03ADD8)MUL(6.5SUB5)DIV((3SUB2)MUL(4ADD2))", ExpectedResult = 1002.0075)]
        public decimal CalculateShouldReturnExpectedResult(string expr)
        {
            IExprSieve exprSieve = new ExprSieve();
            ITokenDescriptorFactory tokenDescriptorFactory = new TokenDescriptorFactory();
            IInfixToPostfixConverter infixToPostfixConverter = new InfixToPostfixConverter(tokenDescriptorFactory);
            ITokenizer tokenizer = new Tokenizer();
            IToRpnConverter toRpnConverter = new ToRpnConverter(exprSieve, infixToPostfixConverter, tokenizer);
            ICalc calc = new YouBastardCalc(toRpnConverter);
            return calc.Calculate(expr);
        }
    }
}
