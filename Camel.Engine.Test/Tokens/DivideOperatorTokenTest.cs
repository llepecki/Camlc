using Lepecki.Playground.Camel.Engine.Tokens;
using NUnit.Framework;
using System.Collections.Generic;

namespace Lepecki.Playground.Camel.Engine.Test.Tokens
{
    [TestFixture]
    public class DivideOperatorTokenTest
    {
        [TestCase(3, 4, ExpectedResult = 0.75, TestOf = typeof(DivideOperatorToken))]
        public decimal OperatorShouldPushCorrectResultToStack(decimal a, decimal b)
        {
            var stack = new Stack<decimal>();
            stack.Push(a);
            stack.Push(b);

            var operatorToken = new DivideOperatorToken();
            operatorToken.PushOrCalculate(stack);

            return stack.Pop();
        }
    }
}
