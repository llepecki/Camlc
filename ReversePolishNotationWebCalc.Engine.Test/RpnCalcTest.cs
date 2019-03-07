using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using Moq;
using NUnit.Framework;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            Token[] tokens =
            {
                new OperandToken(2),
                new OperandToken(3),
                new AddOperatorToken(),
                new OperandToken(5),
                new MultiplyOperatorToken()
            };

            var rpnExpr = new RpnExpr(tokens);

            var toRpnConverterMock = new Mock<IToRpnConverter>();
            toRpnConverterMock.Setup(converter => converter.Convert(It.IsAny<string>())).Returns(rpnExpr);

            ICalc calc = new RpnCalc(toRpnConverterMock.Object);
            double actual = calc.Calculate(string.Empty);

            Assert.AreEqual(25, actual);
        }
    }
}
