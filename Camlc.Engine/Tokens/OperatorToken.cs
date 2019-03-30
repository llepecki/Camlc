using Lepecki.Playground.Camlc.Engine.Abstractions;
using System;
using System.Collections.Generic;

namespace Lepecki.Playground.Camlc.Engine.Tokens
{
    public abstract class OperatorToken : IToken
    {
        protected abstract int ArgCount { get; }

        protected abstract decimal Calculate(decimal[] args);

        public void PushOrCalculate(Stack<decimal> stack)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            decimal[] args = new decimal[ArgCount];

            for (int i = ArgCount - 1; i >= 0; i--)
            {
                args[i] = stack.Pop();
            }

            decimal result = Calculate(args);
            stack.Push(result);
        }
    }
}
