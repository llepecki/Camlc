using System.Collections.Generic;

namespace ReversePolishNotationWebCalc.Engine
{
    public abstract class Token
    {
        public abstract void PutOrCalculate(Stack<double> stack);
    }
}