using Lepecki.Playground.Camel.Engine.Abstractions;
using Lepecki.Playground.Camel.Engine.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.Camel.Engine.Test.Tokens
{
    [TestFixture]
    public class NegateOperatorTokenTest
    {
        [TestCase(3, ExpectedResult = -3, TestOf = typeof(NegationOperatorToken))]
        public decimal OperatorShouldPushCorrectResultToStack(decimal a)
        {
            var stack = new Stack<decimal>();
            stack.Push(a);

            var operatorToken = new NegationOperatorToken();
            operatorToken.PushOrCalculate(stack);

            return stack.Pop();
        }
    }
}
