using System.Collections.Generic;
using Com.Lepecki.Playground.Camlc.Engine.Tokens;
using NUnit.Framework;

namespace Com.Lepecki.Playground.Camlc.Engine.Test.Tokens
{
    [TestFixture(TestOf = typeof(MultiplyOperatorToken))]
    public class MultiplyOperatorTokenTest
    {
        [TestCase(3, 4, ExpectedResult = 12)]
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
