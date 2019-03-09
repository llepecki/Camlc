using System;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Tokens
{
    public abstract class BinaryOperatorToken : OperatorToken
    {
        protected abstract double Calculate(double a, double b);

        protected override int ArgCount => 2;

        protected override double Calculate(double[] args)
        {
            if (args.Length == ArgCount)
            {
                return Calculate(args[0], args[1]);
            }

            throw new ArgumentException("Binary operator only accepts two arguments", nameof(args));
        }
    }
}
