using System.Collections.Generic;
using Com.Lepecki.Playground.Camlc.Engine.Tokens;
using NUnit.Framework;

namespace Com.Lepecki.Playground.Camlc.Engine.Test.Tokens
{
    [TestFixture(TestOf = typeof(SubtractOperatorToken))]
    public class SubtractOperatorTokenTest
    {
        [TestCase(3, 4, ExpectedResult = -1)]
        public decimal OperatorShouldPushCorrectResultToStack(decimal a, decimal b)
        {
            var stack = new Stack<decimal>();
            stack.Push(a);
            stack.Push(b);

            var operatorToken = new SubtractOperatorToken();
            operatorToken.PushOrCalculate(stack);

            return stack.Pop();
        }
    }
}
