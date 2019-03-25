using Lepecki.Playground.Camlc.Engine.Abstractions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Lepecki.Playground.Camlc.Engine.Test
{
    [TestFixture]
    public class ExprSieveTest
    {
        [Test(TestOf = typeof(ExprSieve)), TestCaseSource(typeof(ExprSieveTestCaseSource), nameof(ExprSieveTestCaseSource.TestCases))]
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
                string expr = "(2 add 1.45) mul 3 div (4 sub 1.7)";
                IReadOnlyCollection<string> expected = new[] { "(", "2", "ADD", "1.45", ")", "MUL", "3", "DIV", "(", "4", "SUB", "1.7", ")" };
                yield return new TestCaseData(expr, expected);

                expr = "(2add1.45)mul3div(4sub1.7)";
                expected = new[] { "(", "2", "ADD", "1.45", ")", "MUL", "3", "DIV", "(", "4", "SUB", "1.7", ")" };
                yield return new TestCaseData(expr, expected);

                expr = " (  2   add  1.45 )  mul   3  div (  4   sub  1.7 )  ";
                expected = new[] { "(", "2", "ADD", "1.45", ")", "MUL", "3", "DIV", "(", "4", "SUB", "1.7", ")" };
                yield return new TestCaseData(expr, expected);

                expr = "(2 add 1.4) mul (3 div (4 sub 1.7) sub 0.2)";
                expected = new[] { "(", "2", "ADD", "1.4", ")", "MUL", "(", "3", "DIV", "(", "4", "SUB", "1.7", ")", "SUB", "0.2", ")" };
                yield return new TestCaseData(expr, expected);

                expr = "((2 mul (1.4 sub 0.2)) mul 4 ) mul 3 div (4 sub 1.7)";
                expected = new[] { "(", "(", "2", "MUL", "(", "1.4", "SUB", "0.2", ")", ")", "MUL", "4", ")", "MUL", "3", "DIV", "(", "4", "SUB", "1.7", ")" };
                yield return new TestCaseData(expr, expected);

                expr = "2 pow (9 add neg 3.271)";
                expected = new[] { "2", "POW", "(", "9", "ADD", "NEG", "3.271", ")" };
                yield return new TestCaseData(expr, expected);

                expr = "(2 ADD 1.45) Mul 3 dIv (4 suB 1.7)";
                expected = new[] { "(", "2", "ADD", "1.45", ")", "MUL", "3", "DIV", "(", "4", "SUB", "1.7", ")" };
                yield return new TestCaseData(expr, expected);
            }
        }
    }
}
