using System.Collections.Generic;

namespace ReversePolishNotationWebCalc.Engine
{
    public class OperandToken : Token
    {
        private readonly double _value;

        public OperandToken(double value)
        {
            _value = value;
        }

        public override void PutOrCalculate(Stack<double> stack)
        {
            stack.Push(_value);
        }
    }
}