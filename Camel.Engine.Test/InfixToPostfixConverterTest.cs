using Lepecki.Playground.Camel.Engine.Abstractions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.Camel.Engine.Test
{
    [TestFixture]
    public class InfixToPostfixConverterTest
    {
        [Test(TestOf = typeof(InfixToPostfixConverter)), TestCaseSource(typeof(InfixToPostfixConverterTestCaseSource), nameof(InfixToPostfixConverterTestCaseSource.TestCases))]
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
                IReadOnlyCollection<string> symbols = new[] { "3", "add", "4.2", "mul", "5", "div", "6.781" };
                IReadOnlyCollection<string> expected = new[] { "3", "4.2", "5", "mul", "6.781", "div", "add" };
                yield return new TestCaseData(symbols, expected);
                
                symbols = new[] { "(", "300", "add", "23.11", ")", "mul", "(", "43", "sub", "21", ")", "div", "(", "84.005", "add", "7", ")" };
                expected = new[] { "300", "23.11", "add", "43", "21", "sub", "mul", "84.005", "7", "add", "div" };
                yield return new TestCaseData(symbols, expected);
                
                symbols = new[] { "(", "4000.0001", "add", "8", ")", "mul", "(", "6", "sub", "5", ")", "div", "(", "(", "3", "sub", "2", ")", "mul", "(", "2", "add", "2.231", ")", ")" };
                expected = new[] { "4000.0001", "8", "add", "6", "5", "sub", "mul", "3", "2", "sub", "2", "2.231", "add", "mul", "div" };
                yield return new TestCaseData(symbols, expected);
            }
        }
    }
}
