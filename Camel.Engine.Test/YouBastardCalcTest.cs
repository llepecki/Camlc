using System;
using Lepecki.Playground.Camel.Engine.Abstractions;
using NUnit.Framework;

namespace Lepecki.Playground.Camel.Engine.Test
{
    [TestFixture]
    public class YouBastardCalcTests
    {
        [TestCase("3 mul 4 div 2", ExpectedResult = 6.0000, TestOf = typeof(YouBastardCalc))]
        [TestCase("3 add 4.2 mul 5.5 div 6", ExpectedResult = 6.8500, TestOf = typeof(YouBastardCalc))]
        [TestCase("(300 add 23.05) mul (43.3 sub 21) div (84 add 7)", ExpectedResult = 79.1650, TestOf = typeof(YouBastardCalc))]
        [TestCase("(4000.03 add 8) mul (6.5 sub 5) div ((3 sub 2) mul (4 add 2))", ExpectedResult = 1002.0075, TestOf = typeof(YouBastardCalc))]
        public double CalculateShouldReturnExpectedResult(string expr)
        {
            IExprSieve exprSieve = new ExprSieve();
            ITokenDescriptorFactory tokenDescriptorFactory = new TokenDescriptorFactory();
            IInfixToPostfixConverter infixToPostfixConverter = new InfixToPostfixConverter(tokenDescriptorFactory);
            ITokenizer tokenizer = new Tokenizer();
            IToRpnConverter toRpnConverter = new ToRpnConverter(exprSieve, infixToPostfixConverter, tokenizer);
            ICalc calc = new YouBastardCalc(toRpnConverter);
            return Math.Round(calc.Calculate(expr), 8);
        }
    }
}
