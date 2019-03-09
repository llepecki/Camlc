using System;

namespace Lepecki.Playground.Camel.Engine.Tokens
{
    public class PowerOperatorToken : BinaryOperatorToken
    {
        protected override double Calculate(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}
