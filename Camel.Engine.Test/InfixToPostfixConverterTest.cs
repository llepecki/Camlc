using System.Collections.Generic;
using System.Linq;
using Lepecki.Playground.Camel.Engine.Abstractions;
using NUnit.Framework;

namespace Lepecki.Playground.Camel.Engine.Test
{
    [TestFixture]
    public class InfixToPostfixConverterTest
    {
        [TestCase("3;add;4.2;mul;5;div;6.781", ExpectedResult = new[] { "3", "4.2", "5", "mul", "6.781", "div", "add" }, TestOf = typeof(InfixToPostfixConverter))]
        [TestCase("(;300;add;23.11;);mul;(;43;sub;21;);div;(;84.005;add;7;)", ExpectedResult = new[] { "300", "23.11", "add", "43", "21", "sub", "mul", "84.005", "7", "add", "div" }, TestOf = typeof(InfixToPostfixConverter))]
        [TestCase("(;4000.0001;add;8;);mul;(;6;sub;5;);div;(;(;3;sub;2;);mul;(;2;add;2.231;);)", ExpectedResult = new[] { "4000.0001", "8", "add", "6", "5", "sub", "mul", "3", "2", "sub", "2", "2.231", "add", "mul", "div" }, TestOf = typeof(InfixToPostfixConverter))]
        public IReadOnlyCollection<string> ConvertShouldReturnCollectionOfOperandsAndOperatorsWithoutParenthesisInPostfixNotationOrder(string semicolonSeparatedOperandsAndOperators)
        {
            string[] operandsAndOperators = semicolonSeparatedOperandsAndOperators.Split(';');
            ITokenDescriptorFactory tokenDescriptorFactory = new TokenDescriptorFactory();
            IInfixToPostfixConverter converter = new InfixToPostfixConverter(tokenDescriptorFactory);
            return converter.Convert(operandsAndOperators).Select(tokenDescriptor => tokenDescriptor.ToString()).ToArray();
        }
    }
}
