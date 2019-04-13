using System;

namespace Com.Lepecki.Playground.Camlc.Engine.Tokens
{
    public abstract class BinaryOperatorToken : OperatorToken
    {
        protected abstract decimal Calculate(decimal a, decimal b);

        protected override int ArgCount => 2;

        protected override decimal Calculate(decimal[] args)
        {
            if (args.Length == ArgCount)
            {
                return Calculate(args[0], args[1]);
            }

            throw new ArgumentException("Binary operator only accepts two arguments", nameof(args));
        }
    }
}
