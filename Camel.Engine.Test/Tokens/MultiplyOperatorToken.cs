using Lepecki.Playground.Camel.Engine.Tokens;
using NUnit.Framework;
using System.Collections.Generic;

namespace Lepecki.Playground.Camel.Engine.Test.Tokens
{
    [TestFixture]
    public class MultiplyOperatorTokenTest
    {
        [TestCase(3, 4, ExpectedResult = 12, TestOf = typeof(MultiplyOperatorToken))]
        public decimal OperatorShouldPushCorrectResultToStack(decimal a, decimal b)
        {
            var stack = new Stack<decimal>();
            stack.Push(a);
            stack.Push(b);

            var operatorToken = new MultiplyOperatorToken();
            operatorToken.PushOrCalculate(stack);

            return stack.Pop();
        }
    }
}
