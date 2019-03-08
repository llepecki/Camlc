using System.Collections.Generic;
using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using NUnit.Framework;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Test
{
    [TestFixture]
    public class ExprSieveTest
    {
        [TestCase("(2 add 1.45) mul 3 div (4 sub 1.7)", ExpectedResult = new[] { "(", "2", "add", "1.45", ")", "mul", "3", "div", "(", "4", "sub", "1.7", ")" }, Description = "Normal spacing", TestOf = typeof(ExprSieve))]
        [TestCase("(2add1.45)mul3div(4sub1.7)", ExpectedResult = new[] { "(", "2", "add", "1.45", ")", "mul", "3", "div", "(", "4", "sub", "1.7", ")" }, Description = "Narrow spacing", TestOf = typeof(ExprSieve))]
        [TestCase(" (  2   add  1.45 )  mul   3  div (  4   sub  1.7 )  ", ExpectedResult = new[] { "(", "2", "add", "1.45", ")", "mul", "3", "div", "(", "4", "sub", "1.7", ")" }, Description = "Wide spacing", TestOf = typeof(ExprSieve))]
        [TestCase("(2 add 1.4) mul (3 div (4 sub 1.7) sub 0.2)", ExpectedResult = new[] { "(", "2", "add", "1.4", ")", "mul", "(", "3", "div", "(", "4", "sub", "1.7", ")", "sub", "0.2", ")" }, Description = "Double nested parenthesis", TestOf = typeof(ExprSieve))]
        [TestCase("((2 mul (1.4 sub 0.2)) mul 4 ) mul 3 div (4 sub 1.7)", ExpectedResult = new[] { "(", "(", "2", "mul", "(", "1.4", "sub", "0.2", ")", ")", "mul", "4", ")", "mul", "3", "div", "(", "4", "sub", "1.7", ")" }, Description = "Triple nested parenthesis", TestOf = typeof(ExprSieve))]
        [TestCase("2 pow (9 add neg 3.271)", ExpectedResult = new[] { "2", "pow", "(", "9", "add", "neg", "3.271", ")" }, Description = "Power and negation", TestOf = typeof(ExprSieve))]
        public IReadOnlyCollection<string> SieveShouldReturnCollectionOfExpectedOperandsAndOperators(string expr)
        {
            IExprSieve sieve = new ExprSieve();
            return sieve.Sieve(expr);
        }
    }
}
