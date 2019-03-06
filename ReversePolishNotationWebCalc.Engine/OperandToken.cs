using System;
using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class OperandToken : Token
    {
        private readonly double _value;

        public OperandToken(double value)
        {
            _value = value;
        }

        public override void PushOrCalculate(Stack<double> stack)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }
            
            stack.Push(_value);
        }
    }
}