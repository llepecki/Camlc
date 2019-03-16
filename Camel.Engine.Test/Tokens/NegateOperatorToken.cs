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
        public double OperatorShouldPushCorrectResultToStack(double a)
        {
            var stack = new Stack<double>();
            stack.Push(a);

            var operatorToken = new NegationOperatorToken();
            operatorToken.PushOrCalculate(stack);

            return Math.Round(stack.Pop(), 8);
        }
    }
}
