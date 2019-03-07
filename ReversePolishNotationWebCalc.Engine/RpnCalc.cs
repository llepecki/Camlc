using System;
using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class RpnCalc : ICalc
    {
        private readonly IToRpnConverter _toRpnConverter;

        public RpnCalc(IToRpnConverter toRpnConverter)
        {
            _toRpnConverter = toRpnConverter ?? throw new ArgumentNullException(nameof(toRpnConverter));
        }

        public double Calculate(string expr)
        {
            RpnExpr rpnExpr = _toRpnConverter.Convert(expr);

            var stack = new Stack<double>();

            foreach (Token token in rpnExpr)
            {
                token.PushOrCalculate(stack);
            }

            return stack.Pop();
        }
    }
}
