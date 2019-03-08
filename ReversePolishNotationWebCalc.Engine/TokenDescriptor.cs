using System.Text.RegularExpressions;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class TokenDescriptor
    {
        private readonly Regex _operandRegex = new Regex(Patterns.Decimal);

        public TokenDescriptor(string source, bool isOperand, bool isOperator, bool isLeftParenthesis, bool isRightParenthesis, int priority)
        {
            Source = source;
            IsOperand = isOperand;
            IsOperator = isOperator;
            IsLeftParenthesis = isLeftParenthesis;
            IsRightParenthesis = isRightParenthesis;
            Priority = priority;
        }

        public string Source { get; }

        public bool IsOperand { get; }

        public bool IsOperator { get; }

        public bool IsLeftParenthesis { get; }

        public bool IsRightParenthesis { get; }

        public int Priority { get; }
    }
}
