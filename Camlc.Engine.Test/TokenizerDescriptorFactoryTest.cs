using Lepecki.Playground.Camlc.Engine.Abstractions;
using NUnit.Framework;

namespace Lepecki.Playground.Camlc.Engine.Test
{
    [TestFixture]
    public class TokenizerDescriptorFactoryTest
    {
        [TestCase("42", TestOf = typeof(TokenDescriptorFactory))]
        [TestCase("7007.1001", TestOf = typeof(TokenDescriptorFactory))]
        public void CreateOperand(string symbol)
        {
            ITokenDescriptorFactory factory = new TokenDescriptorFactory();
            TokenDescriptor tokenDescriptor = factory.Create(symbol);

            Assert.True(tokenDescriptor.IsOperand);
            Assert.False(tokenDescriptor.IsOperator);
            Assert.False(tokenDescriptor.IsLeftParenthesis);
            Assert.False(tokenDescriptor.IsRightParenthesis);
            Assert.AreEqual(0, tokenDescriptor.Precedence);
        }

        [TestCase("ADD", 1, TestOf = typeof(TokenDescriptorFactory))]
        [TestCase("SUB", 1, TestOf = typeof(TokenDescriptorFactory))]
        [TestCase("MUL", 2, TestOf = typeof(TokenDescriptorFactory))]
        [TestCase("DIV", 2, TestOf = typeof(TokenDescriptorFactory))]
        [TestCase("POW", 3, TestOf = typeof(TokenDescriptorFactory))]
        [TestCase("NEG", 4, TestOf = typeof(TokenDescriptorFactory))]
        public void CreateOperator(string symbol, int expectedPriority)
        {
            ITokenDescriptorFactory factory = new TokenDescriptorFactory();
            TokenDescriptor tokenDescriptor = factory.Create(symbol);

            Assert.False(tokenDescriptor.IsOperand);
            Assert.True(tokenDescriptor.IsOperator);
            Assert.False(tokenDescriptor.IsLeftParenthesis);
            Assert.False(tokenDescriptor.IsRightParenthesis);
            Assert.AreEqual(expectedPriority, tokenDescriptor.Precedence);
        }

        [Test(TestOf = typeof(TokenDescriptorFactory))]
        public void CreateLeftParenthesis()
        {
            ITokenDescriptorFactory factory = new TokenDescriptorFactory();
            TokenDescriptor tokenDescriptor = factory.Create("(");

            Assert.False(tokenDescriptor.IsOperand);
            Assert.False(tokenDescriptor.IsOperator);
            Assert.True(tokenDescriptor.IsLeftParenthesis);
            Assert.False(tokenDescriptor.IsRightParenthesis);
            Assert.AreEqual(5, tokenDescriptor.Precedence);
        }

        [Test(TestOf = typeof(TokenDescriptorFactory))]
        public void CreateRightParenthesis()
        {
            ITokenDescriptorFactory factory = new TokenDescriptorFactory();
            TokenDescriptor tokenDescriptor = factory.Create(")");

            Assert.False(tokenDescriptor.IsOperand);
            Assert.False(tokenDescriptor.IsOperator);
            Assert.False(tokenDescriptor.IsLeftParenthesis);
            Assert.True(tokenDescriptor.IsRightParenthesis);
            Assert.AreEqual(5, tokenDescriptor.Precedence);
        }
    }
}
