using System.Collections.Generic;

namespace ReversePolishNotationWebCalc.Engine
{
    public abstract class OperatorToken : Token
    {
        public abstract int ArgCount { get; }

        public abstract double Calculate(double[] args);

        public override void PutOrCalculate(Stack<double> stack)
        {
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