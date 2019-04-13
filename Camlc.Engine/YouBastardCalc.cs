using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Com.Lepecki.Playground.Camlc.Engine.Abstractions;
using Com.Lepecki.Playground.Camlc.Engine.Tokens;

namespace Com.Lepecki.Playground.Camlc.Engine
{
    // Etymology of this class' name can by found in "Pyramids" by Terry Pratchett.
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

        public async Task<decimal> CalculateAsync(string expr, CancellationToken cancellationToken)
        {
            RpnExpr rpnExpr = await _toRpnConverter.ConvertAsync(expr, cancellationToken);

            var stack = new Stack<decimal>();

            foreach (Token token in rpnExpr)
            {
                await token.PushOrCalculateAsync(stack, cancellationToken);
            }

            return stack.Pop();
        }
    }
}
