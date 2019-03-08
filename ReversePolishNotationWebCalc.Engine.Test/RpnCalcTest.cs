using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using NUnit.Framework;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Test
{
    [TestFixture]
    public class Tests
    {
        [TestCase("3 add 4.2 mul 5.5 div 6", ExpectedResult = 6.85, TestOf = typeof(RpnCalc))]
        [TestCase("(300 add 23.05) mul (43.3 sub 21) div (84 add 7)", ExpectedResult = 79.165, TestOf = typeof(InfixToPostfixConverter))]
        [TestCase("(4000.03 add 8) mul (6.5 sub 5) div ((3 sub 2) mul (4 add 2))", ExpectedResult = 1002.0075, TestOf = typeof(InfixToPostfixConverter))]
        public double CalculateShouldReturnExpectedResult(string expr)
        {
            IExprSieve exprSieve = new ExprSieve();
            IInfixToPostfixConverter infixToPostfixConverter = new InfixToPostfixConverter();
            ITokenizer tokenizer = new Tokenizer();
            IToRpnConverter toRpnConverter = new ToRpnConverter(exprSieve, infixToPostfixConverter, tokenizer);

            ICalc calc = new RpnCalc(toRpnConverter);
            return calc.Calculate(expr);
        }
    }
}
