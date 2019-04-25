using Com.Lepecki.Playground.Camlc.Engine.Abstractions;
using NUnit.Framework;

namespace Com.Lepecki.Playground.Camlc.Engine.Test
{
    [TestFixture(TestOf = typeof(TokenDescriptorFactory))]
    public class TokenizerDescriptorFactoryTest
    {
        [TestCase("42")]
        [TestCase("7007.1001")]
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

        [TestCase("ADD", 1)]
        [TestCase("SUB", 1)]
        [TestCase("MUL", 2)]
        [TestCase("DIV", 2)]
        [TestCase("POW", 3)]
        [TestCase("NEG", 4)]
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

        [Test]
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

        [Test]
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
