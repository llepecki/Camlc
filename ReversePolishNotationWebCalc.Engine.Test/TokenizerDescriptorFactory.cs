using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using NUnit.Framework;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Test
{
    [TestFixture]
    public class TokenizerDescriptorFactory
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
            Assert.AreEqual(0, tokenDescriptor.Priority);
        }

        [TestCase("add", 1, TestOf = typeof(TokenDescriptorFactory))]
        [TestCase("sub", 1, TestOf = typeof(TokenDescriptorFactory))]
        [TestCase("mul", 2, TestOf = typeof(TokenDescriptorFactory))]
        [TestCase("div", 2, TestOf = typeof(TokenDescriptorFactory))]
        [TestCase("pow", 3, TestOf = typeof(TokenDescriptorFactory))]
        [TestCase("neg", 4, TestOf = typeof(TokenDescriptorFactory))]
        public void CreateOperator(string symbol, int expectedPriority)
        {
            ITokenDescriptorFactory factory = new TokenDescriptorFactory();
            TokenDescriptor tokenDescriptor = factory.Create(symbol);

            Assert.False(tokenDescriptor.IsOperand);
            Assert.True(tokenDescriptor.IsOperator);
            Assert.False(tokenDescriptor.IsLeftParenthesis);
            Assert.False(tokenDescriptor.IsRightParenthesis);
            Assert.AreEqual(expectedPriority, tokenDescriptor.Priority);
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
            Assert.AreEqual(5, tokenDescriptor.Priority);
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
            Assert.AreEqual(5, tokenDescriptor.Priority);
        }
    }
}
