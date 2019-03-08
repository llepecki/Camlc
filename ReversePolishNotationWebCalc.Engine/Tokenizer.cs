using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class Tokenizer : ITokenizer
    {
        private readonly Regex _operandRegex = new Regex(@"^\d+(.\d+)?$");

        public Token Create(string operandOrOperator)
        {
            if (_operandRegex.IsMatch(operandOrOperator))
            {
                return new OperandToken(Double.Parse(operandOrOperator, CultureInfo.InvariantCulture));
            }

            switch (operandOrOperator)
            {
                case "add": return new AddOperatorToken();
                case "sub": return new SubtractOperatorToken();
                case "mul": return new MultiplyOperatorToken();
                case "div": return new DivideOperatorToken();
                case "pow": return new PowerOperatorToken();
                case "neg": return new NegationOperatorToken();

                default:
                    throw new ArgumentException($"Unknown operand: {operandOrOperator}");
            }
        }
    }
}
