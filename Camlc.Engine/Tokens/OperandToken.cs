using Lepecki.Playground.Camlc.Engine.Abstractions;
using System;
using System.Collections.Generic;

namespace Lepecki.Playground.Camlc.Engine.Tokens
{
    public class OperandToken : IToken
    {
        private readonly decimal _value;

        public OperandToken(decimal value)
        {
            _value = value;
        }

        public void PushOrCalculate(Stack<decimal> stack)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            stack.Push(_value);
        }
    }
}
