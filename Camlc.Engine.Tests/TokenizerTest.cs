using System;
using Com.Lepecki.Playground.Camlc.Engine.Abstractions;
using Com.Lepecki.Playground.Camlc.Engine.Tokens;
using NUnit.Framework;

namespace Com.Lepecki.Playground.Camlc.Engine.Test
{
    [TestFixture(TestOf = typeof(Tokenizer))]
    public class TokenizerTest
    {
        [TestCase("42", ExpectedResult = typeof(OperandToken))]
        [TestCase("42.789", ExpectedResult = typeof(OperandToken))]
        [TestCase("ADD", ExpectedResult = typeof(AddOperatorToken))]
        [TestCase("SUB", ExpectedResult = typeof(SubtractOperatorToken))]
        [TestCase("MUL", ExpectedResult = typeof(MultiplyOperatorToken))]
        [TestCase("DIV", ExpectedResult = typeof(DivideOperatorToken))]
        [TestCase("POW", ExpectedResult = typeof(PowerOperatorToken))]
        [TestCase("NEG", ExpectedResult = typeof(NegationOperatorToken))]
        public Type TokenizerShouldCreateTokenCorrespondingToItsStringRepresentation(string symbol)
        {
            ITokenizer tokenizer = new Tokenizer();
            ITokenDescriptorFactory tokenDescriptorFactory = new TokenDescriptorFactory();
            Token token = tokenizer.Create(tokenDescriptorFactory.Create(symbol));
            return token.GetType();
        }
    }
}
