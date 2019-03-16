using Lepecki.Playground.Camel.Engine.Abstractions;
using Lepecki.Playground.Camel.Engine.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.Camel.Engine.Test.Tokens
{
    [TestFixture]
    public class MultiplyOperatorTokenTest
    {
        [TestCase(3, 4, ExpectedResult = 12, TestOf = typeof(MultiplyOperatorToken))]
        public double OperatorShouldPushCorrectResultToStack(double a, double b)
        {
            var stack = new Stack<double>();
            stack.Push(a);
            stack.Push(b);

            var operatorToken = new MultiplyOperatorToken();
            operatorToken.PushOrCalculate(stack);

            return Math.Round(stack.Pop(), 8);
        }
    }
}
