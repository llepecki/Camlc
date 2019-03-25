using Lepecki.Playground.Camlc.Engine.Abstractions;
using Lepecki.Playground.Camlc.Engine.Tokens;
using NUnit.Framework;
using System;

namespace Lepecki.Playground.Camlc.Engine.Test
{
    [TestFixture]
    public class TokenizerTest
    {
        [TestCase("42", ExpectedResult = typeof(OperandToken), TestOf = typeof(Tokenizer))]
        [TestCase("42.789", ExpectedResult = typeof(OperandToken), TestOf = typeof(Tokenizer))]
        [TestCase("ADD", ExpectedResult = typeof(AddOperatorToken), TestOf = typeof(Tokenizer))]
        [TestCase("SUB", ExpectedResult = typeof(SubtractOperatorToken), TestOf = typeof(Tokenizer))]
        [TestCase("MUL", ExpectedResult = typeof(MultiplyOperatorToken), TestOf = typeof(Tokenizer))]
        [TestCase("DIV", ExpectedResult = typeof(DivideOperatorToken), TestOf = typeof(Tokenizer))]
        [TestCase("POW", ExpectedResult = typeof(PowerOperatorToken), TestOf = typeof(Tokenizer))]
        [TestCase("NEG", ExpectedResult = typeof(NegationOperatorToken), TestOf = typeof(Tokenizer))]
        public Type TokenizerShouldCreateTokenCorrespondingToItsStringRepresentation(string symbol)
        {
            ITokenizer tokenizer = new Tokenizer();
            ITokenDescriptorFactory tokenDescriptorFactory = new TokenDescriptorFactory();
            IToken token = tokenizer.Create(tokenDescriptorFactory.Create(symbol));
            return token.GetType();
        }
    }
}
