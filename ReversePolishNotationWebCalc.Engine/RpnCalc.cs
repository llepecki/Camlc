using System;
using System.Collections.Generic;

namespace ReversePolishNotationWebCalc.Engine
{
    public class RpnCalc : ICalc
    {
        private readonly IToRpnConverter _toRpnConverter;

        public RpnCalc(IToRpnConverter toRpnConverter)
        {
            if (toRpnConverter == null)
            {
                throw new ArgumentNullException(nameof(toRpnConverter));
            }

            _toRpnConverter = toRpnConverter;
        }

        public double Calculate(string expr)
        {
            RpnExpr rpnExpr = _toRpnConverter.Convert(expr);
            
            var stack = new Stack<double>();

            foreach (Token token in rpnExpr)
            {
                token.PutOrCalculate(stack);
            }

            return stack.Pop();
        }
    }
}