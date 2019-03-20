using System;

namespace Lepecki.Playground.Camel.Engine.Tokens
{
    public abstract class UnaryOperatorToken : OperatorToken
    {
        protected abstract double Calculate(double a);

        protected override int ArgCount => 1;

        protected override double Calculate(double[] args)
        {
            if (args.Length == ArgCount)
            {
                return Calculate(args[0]);
            }

            throw new ArgumentException("Unary operator only accepts one argument", nameof(args));
        }
    }
}
