using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Com.Lepecki.Playground.Camlc.Engine.Abstractions;
using NUnit.Framework;

namespace Com.Lepecki.Playground.Camlc.Engine.Test
{
    [TestFixture(TestOf = typeof(InfixToPostfixConverter))]
    public class InfixToPostfixConverterTest
    {
        [TestCaseSource(typeof(InfixToPostfixConverterTestCaseSource), nameof(InfixToPostfixConverterTestCaseSource.TestCases))]
        public void ConvertShouldReturnCollectionOfSymbolsWithoutParenthesisInPostfixNotationOrder(IReadOnlyCollection<string> symbols, IReadOnlyCollection<string> expected)
        {
            ITokenDescriptorFactory tokenDescriptorFactory = new TokenDescriptorFactory();
            IInfixToPostfixConverter converter = new InfixToPostfixConverter(tokenDescriptorFactory);
            IReadOnlyCollection<string> actual = converter.Convert(symbols).Select(tokenDescriptor => tokenDescriptor.ToString()).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }

    public class InfixToPostfixConverterTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                IReadOnlyCollection<string> symbols = new[] { "3", "ADD", "4.2", "MUL", "5", "DIV", "6.781" };
                IReadOnlyCollection<string> expected = new[] { "3", "4.2", "5", "MUL", "6.781", "DIV", "ADD" };
                yield return new TestCaseData(symbols, expected);

                symbols = new[] { "(", "300", "ADD", "23.11", ")", "MUL", "(", "43", "SUB", "21", ")", "DIV", "(", "84.005", "ADD", "7", ")" };
                expected = new[] { "300", "23.11", "ADD", "43", "21", "SUB", "MUL", "84.005", "7", "ADD", "DIV" };
                yield return new TestCaseData(symbols, expected);

                symbols = new[] { "(", "4000.0001", "ADD", "8", ")", "MUL", "(", "6", "SUB", "5", ")", "DIV", "(", "(", "3", "SUB", "2", ")", "MUL", "(", "2", "ADD", "2.231", ")", ")" };
                expected = new[] { "4000.0001", "8", "ADD", "6", "5", "SUB", "MUL", "3", "2", "SUB", "2", "2.231", "ADD", "MUL", "DIV" };
                yield return new TestCaseData(symbols, expected);
            }
        }
    }
}
