using NUnit.Framework;
using System.Collections.Generic;
using Com.Lepecki.Playground.Camlc.Engine.Tokens;

namespace Com.Lepecki.Playground.Camlc.Engine.Test.Tokens
{
    [TestFixture(TestOf = typeof(DivideOperatorToken))]
    public class DivideOperatorTokenTest
    {
        [TestCase(3, 4, ExpectedResult = 0.75)]
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
