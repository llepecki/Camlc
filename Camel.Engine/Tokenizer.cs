using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Lepecki.Playground.Camel.Engine.Abstractions;
using Lepecki.Playground.Camel.Engine.Tokens;

namespace Lepecki.Playground.Camel.Engine
{
    public class Tokenizer : ITokenizer
    {
        private readonly Regex _operandRegex = new Regex(Patterns.Decimal);

        public Token Create(TokenDescriptor tokenDescriptor)
        {
            if (tokenDescriptor.IsOperand)
            {
                return new OperandToken(Double.Parse(tokenDescriptor.ToString(), CultureInfo.InvariantCulture));
            }

            if (tokenDescriptor.IsOperator)
            {
                switch (tokenDescriptor.ToString())
                {
                    case Operators.Add: return new AddOperatorToken();
                    case Operators.Subtract: return new SubtractOperatorToken();
                    case Operators.Multiply: return new MultiplyOperatorToken();
                    case Operators.Divide: return new DivideOperatorToken();
                    case Operators.Power: return new PowerOperatorToken();
                    case Operators.Negate: return new NegationOperatorToken();

                    default:
                        throw new ArgumentException($"Unknown operator: {tokenDescriptor}");
                }
            }

            if (tokenDescriptor.IsLeftParenthesis || tokenDescriptor.IsRightParenthesis)
            {
                throw new InvalidOperationException("A parenthesis can't be turned into a token");
            }

            throw new InvalidOperationException("Invalid token descriptor");
        }
    }
}
