using System;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class PowerOperatorToken : BinaryOperatorToken
    {
        protected override double Calculate(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}
