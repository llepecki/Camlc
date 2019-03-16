using Lepecki.Playground.Camel.Engine.Abstractions;
using Lepecki.Playground.Camel.Engine.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.Camel.Engine.Test.Tokens
{
    [TestFixture]
    public class AddOperatorTokenTest
    {
        [TestCase(3, 4, ExpectedResult = 7, TestOf = typeof(AddOperatorToken))]
        public double OperatorShouldPushCorrectResultToStack(double a, double b)
        {
            var stack = new Stack<double>();
            stack.Push(a);
            stack.Push(b);

            var operatorToken = new AddOperatorToken();
            operatorToken.PushOrCalculate(stack);

            return Math.Round(stack.Pop(), 8);
        }
    }
}
