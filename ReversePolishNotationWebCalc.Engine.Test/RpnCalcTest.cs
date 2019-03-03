using Moq;
using NUnit.Framework;
using ReversePolishNotationWebCalc.Engine;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var factory = new BinaryOperatorTokenFactory();

            var rpnExpr = new RpnExpr();
            rpnExpr.Add(new OperandToken(2));
            rpnExpr.Add(new OperandToken(3));
            rpnExpr.Add(factory.Create("plus"));
            rpnExpr.Add(new OperandToken(5));
            rpnExpr.Add(factory.Create("multiply"));

            var toRpnConverterMock = new Mock<IToRpnConverter>();
            toRpnConverterMock.Setup(converter => converter.Convert(It.IsAny<string>())).Returns(rpnExpr);

            ICalc calc = new RpnCalc(toRpnConverterMock.Object);
            double actual = calc.Calculate("2 3 + 5 *");

            Assert.AreEqual(25, actual);
        }
    }
}