using System;

namespace Lepecki.Playground.Camlc.Engine.Tokens
{
    public abstract class UnaryOperatorToken : OperatorToken
    {
        protected abstract decimal Calculate(decimal a);

        protected override int ArgCount => 1;

        protected override decimal Calculate(decimal[] args)
        {
            if (args.Length == ArgCount)
            {
                return Calculate(args[0]);
            }

            throw new ArgumentException("Unary operator only accepts one argument", nameof(args));
        }
    }
}
