using System;

namespace Lepecki.Playground.Camel.Engine.Tokens
{
    public class PowerOperatorToken : BinaryOperatorToken
    {
        protected override decimal Calculate(decimal a, decimal b)
        {
            return (decimal) Math.Pow(decimal.ToDouble(a), decimal.ToDouble(b));
        }
    }
}
