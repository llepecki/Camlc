using Lepecki.Playground.Camel.Engine.Abstractions;
using Lepecki.Playground.Camel.Engine.Tokens;
using System;
using System.Collections.Generic;

namespace Lepecki.Playground.Camel.Engine
{
    // etymology of this class' name can by found in "Pyramids" by Terry Pratchett
    public class YouBastardCalc : ICalc
    {
        private readonly IToRpnConverter _toRpnConverter;

        public YouBastardCalc(IToRpnConverter toRpnConverter)
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
