using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Com.Lepecki.Playground.Camlc.Engine.Abstractions;

namespace Com.Lepecki.Playground.Camlc.Engine.Test
{
    [TestFixture(TestOf = typeof(ExprSieve))]
    public class ExprSieveTest
    {
        [TestCaseSource(typeof(ExprSieveTestCaseSource), nameof(ExprSieveTestCaseSource.TestCases))]
        public void SieveShouldReturnCollectionOfExpectedSymbols(string expr, IReadOnlyCollection<string> expected)
        {
            IExprSieve sieve = new ExprSieve();
            IReadOnlyCollection<string> actual = sieve.Sieve(expr);
            CollectionAssert.AreEqual(expected, actual);
        }
    }

    public class ExprSieveTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                string expr = "(2ADD1.45)MUL3DIV(4SUB1.7)";
                IReadOnlyCollection<string> expected = new[] { "(", "2", "ADD", "1.45", ")", "MUL", "3", "DIV", "(", "4", "SUB", "1.7", ")" };
                yield return new TestCaseData(expr, expected);

                expr = "(2ADD1.4)MUL(3DIV(4SUB1.7)SUB0.2)";
                expected = new[] { "(", "2", "ADD", "1.4", ")", "MUL", "(", "3", "DIV", "(", "4", "SUB", "1.7", ")", "SUB", "0.2", ")" };
                yield return new TestCaseData(expr, expected);

                expr = "((2MUL(1.4SUB0.2))MUL4)MUL3DIV(4SUB1.7)";
                expected = new[] { "(", "(", "2", "MUL", "(", "1.4", "SUB", "0.2", ")", ")", "MUL", "4", ")", "MUL", "3", "DIV", "(", "4", "SUB", "1.7", ")" };
                yield return new TestCaseData(expr, expected);

                expr = "2POW(9ADDNEG3.271)";
                expected = new[] { "2", "POW", "(", "9", "ADD", "NEG", "3.271", ")" };
                yield return new TestCaseData(expr, expected);
            }
        }
    }
}
