using Lepecki.Playground.Camel.Engine.Abstractions;
using Lepecki.Playground.Camel.Engine.Tokens;
using NUnit.Framework;
using System;

namespace Lepecki.Playground.Camel.Engine.Test
{
    [TestFixture]
    public class TokenizerTest
    {
        [TestCase("42", ExpectedResult = typeof(OperandToken), TestOf = typeof(Tokenizer))]
        [TestCase("42.789", ExpectedResult = typeof(OperandToken), TestOf = typeof(Tokenizer))]
        [TestCase("add", ExpectedResult = typeof(AddOperatorToken), TestOf = typeof(Tokenizer))]
        [TestCase("sub", ExpectedResult = typeof(SubtractOperatorToken), TestOf = typeof(Tokenizer))]
        [TestCase("mul", ExpectedResult = typeof(MultiplyOperatorToken), TestOf = typeof(Tokenizer))]
        [TestCase("div", ExpectedResult = typeof(DivideOperatorToken), TestOf = typeof(Tokenizer))]
        [TestCase("pow", ExpectedResult = typeof(PowerOperatorToken), TestOf = typeof(Tokenizer))]
        [TestCase("neg", ExpectedResult = typeof(NegationOperatorToken), TestOf = typeof(Tokenizer))]
        public Type TokenizerShouldCreateTokenCorrespondingToItsStringRepresentation(string symbol)
        {
            ITokenizer tokenizer = new Tokenizer();
            ITokenDescriptorFactory tokenDescriptorFactory = new TokenDescriptorFactory();
            Token token = tokenizer.Create(tokenDescriptorFactory.Create(symbol));
            return token.GetType();
        }
    }
}
