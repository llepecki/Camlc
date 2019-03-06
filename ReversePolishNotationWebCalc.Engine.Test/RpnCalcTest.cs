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
            var factory = new BinaryOperatorTokenFactory();

            Token[] tokens =
            {
                new OperandToken(2),
                new OperandToken(3),
                factory.Create("plus"),
                new OperandToken(5),
                factory.Create("multiply")
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