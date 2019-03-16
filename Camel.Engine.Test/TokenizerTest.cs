using System;
using Lepecki.Playground.Camel.Engine.Abstractions;
using Lepecki.Playground.Camel.Engine.Tokens;
using NUnit.Framework;

namespace Lepecki.Playground.Camel.Engine.Test
{
    [TestFixture]
    public class TokenizerTest
    {
        [TestCase("42", ExpectedResult = typeof(OperandToken), Description = "Operand", TestOf = typeof(Tokenizer))]
        [TestCase("42.789", ExpectedResult = typeof(OperandToken), Description = "Operand", TestOf = typeof(Tokenizer))]
        [TestCase("add", ExpectedResult = typeof(AddOperatorToken), Description = "Add", TestOf = typeof(Tokenizer))]
        [TestCase("sub", ExpectedResult = typeof(SubtractOperatorToken), Description = "Subtract", TestOf = typeof(Tokenizer))]
        [TestCase("mul", ExpectedResult = typeof(MultiplyOperatorToken), Description = "Multiply", TestOf = typeof(Tokenizer))]
        [TestCase("div", ExpectedResult = typeof(DivideOperatorToken), Description = "Divide", TestOf = typeof(Tokenizer))]
        [TestCase("pow", ExpectedResult = typeof(PowerOperatorToken), Description = "Power", TestOf = typeof(Tokenizer))]
        [TestCase("neg", ExpectedResult = typeof(NegationOperatorToken), Description = "Negation", TestOf = typeof(Tokenizer))]
        public Type TokenizerShouldCreateTokenCorrespondingToItsStringRepresentation(string symbol)
        {
            ITokenizer tokenizer = new Tokenizer();
            ITokenDescriptorFactory tokenDescriptorFactory = new TokenDescriptorFactory();
            Token token = tokenizer.Create(tokenDescriptorFactory.Create(symbol));
            return token.GetType();
        }
    }
}
