using Lepecki.Playground.Camlc.Engine.Abstractions;
using Lepecki.Playground.Camlc.Engine.Tokens;
using System;
using System.Collections.Generic;

namespace Lepecki.Playground.Camlc.Engine
{
    // etymology of this class' name can by found in "Pyramids" by Terry Pratchett
    public class YouBastardCalc : ICalc
    {
        private readonly IToRpnConverter _toRpnConverter;

        public YouBastardCalc(IToRpnConverter toRpnConverter)
        {
            _toRpnConverter = toRpnConverter ?? throw new ArgumentNullException(nameof(toRpnConverter));
        }

        public decimal Calculate(string expr)
        {
            RpnExpr rpnExpr = _toRpnConverter.Convert(expr);

            var stack = new Stack<decimal>();

            foreach (Token token in rpnExpr)
            {
                token.PushOrCalculate(stack);
            }

            return stack.Pop();
        }
    }
}
