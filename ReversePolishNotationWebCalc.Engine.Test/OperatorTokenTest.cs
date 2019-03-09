using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Tokens;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Test
{
    [TestFixture]
    public class OperatorTokenTest
    {
        [TestCaseSource(typeof(TokenTestData), nameof(TokenTestData.UnaryTokenTestCases))]
        public double Test(OperatorToken operatorToken, double a)
        {
            var stack = new Stack<double>();
            stack.Push(a);

            operatorToken.PushOrCalculate(stack);

            return Math.Round(stack.Pop(), 8);
        }
        
        [TestCaseSource(typeof(TokenTestData), nameof(TokenTestData.BinaryTokenTestCases))]
        public double Test(OperatorToken operatorToken, double a, double b)
        {
            var stack = new Stack<double>();
            stack.Push(a);
            stack.Push(b);

            operatorToken.PushOrCalculate(stack);

            return Math.Round(stack.Pop(), 8);
        }

        private class TokenTestData
        {
            public static IEnumerable UnaryTokenTestCases
            {
                get
                {
                    yield return new TestCaseData(new NegationOperatorToken(), 13.6).Returns(-13.6);
                }
            }
            
            public static IEnumerable BinaryTokenTestCases
            {
                get
                {
                    yield return new TestCaseData(new AddOperatorToken(), 3087.8271, 41.007).Returns(3128.8341);
                    yield return new TestCaseData(new SubtractOperatorToken(), 3087.8271, 41.007).Returns(3046.8201);
                    yield return new TestCaseData(new MultiplyOperatorToken(), 3087.8271, 41.007).Returns(126622.5258897);
                    yield return new TestCaseData(new DivideOperatorToken(), 3087.8271, 41.007).Returns(75.3);
                    yield return new TestCaseData(new PowerOperatorToken(), 2.5, 3).Returns(15.625);
                }
            }
        }
    }
}