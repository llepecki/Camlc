using System;
using System.Text.RegularExpressions;
using Com.Lepecki.Playground.Camlc.Engine.Abstractions;

namespace Com.Lepecki.Playground.Camlc.Engine
{
    public class TokenDescriptorFactory : ITokenDescriptorFactory
    {
        private static readonly Regex Decimal = new Regex(@"^\d+(.\d+)?$", RegexOptions.Singleline);

        public TokenDescriptor Create(string symbol)
        {
            if (Decimal.IsMatch(symbol))
            {
                return new TokenDescriptor(symbol, true, false, false, false, 0);
            }

            switch (symbol)
            {
                case Operators.Add:
                case Operators.Subtract:
                    return new TokenDescriptor(symbol, false, true, false, false, 1);

                case Operators.Multiply:
                case Operators.Divide:
                    return new TokenDescriptor(symbol, false, true, false, false, 2);

                case Operators.Power:
                    return new TokenDescriptor(symbol, false, true, false, false, 3);

                case Operators.Negate:
                    return new TokenDescriptor(symbol, false, true, false, false, 4);

                case Operators.LeftParenthesis:
                    return new TokenDescriptor(symbol, false, false, true, false, 5);

                case Operators.RightParenthesis:
                    return new TokenDescriptor(symbol, false, false, false, true, 5);
            }

            throw new ArgumentException($"Unknown symbol: {symbol}");
        }
    }
}
