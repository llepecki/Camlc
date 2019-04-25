using System.Collections.Generic;
using Com.Lepecki.Playground.Camlc.Engine.Tokens;
using NUnit.Framework;

namespace Com.Lepecki.Playground.Camlc.Engine.Test.Tokens
{
    [TestFixture(TestOf = typeof(PowerOperatorToken))]
    public class PowerOperatorTokenTest
    {
        [TestCase(3, 4, ExpectedResult = 81)]
        public decimal OperatorShouldPushCorrectResultToStack(decimal a, decimal b)
        {
            var stack = new Stack<decimal>();
            stack.Push(a);
            stack.Push(b);

            var operatorToken = new PowerOperatorToken();
            operatorToken.PushOrCalculate(stack);

            return stack.Pop();
        }
    }
}
