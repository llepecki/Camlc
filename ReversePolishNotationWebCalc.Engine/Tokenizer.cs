using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class Tokenizer : ITokenizer
    {
        private readonly Regex _operandRegex = new Regex(Patterns.Decimal);

        public Token Create(string symbol)
        {
            if (_operandRegex.IsMatch(symbol))
            {
                return new OperandToken(Double.Parse(symbol, CultureInfo.InvariantCulture));
            }

            switch (symbol)
            {
                case Operators.Add: return new AddOperatorToken();
                case Operators.Subtract: return new SubtractOperatorToken();
                case Operators.Multiply: return new MultiplyOperatorToken();
                case Operators.Divide: return new DivideOperatorToken();
                case Operators.Power: return new PowerOperatorToken();
                case Operators.Negate: return new NegationOperatorToken();

                default:
                    throw new ArgumentException($"Unknown operand: {symbol}");
            }
        }
    }
}
