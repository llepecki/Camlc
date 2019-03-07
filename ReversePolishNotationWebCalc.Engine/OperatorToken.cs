using System;
using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public abstract class OperatorToken : Token
    {
        protected abstract int ArgCount { get; }

        protected abstract double Calculate(double[] args);

        public override void PushOrCalculate(Stack<double> stack)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            double[] args = new double[ArgCount];

            for (int i = 0; i < ArgCount; i++)
            {
                args[i] = stack.Pop();
            }

            double result = Calculate(args);
            stack.Push(result);
        }
    }
}
