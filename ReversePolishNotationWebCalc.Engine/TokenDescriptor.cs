using System;
using System.Text.RegularExpressions;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class TokenDescriptor // TODO: add nice debugger representation
    {
        private readonly string _symbol;

        public TokenDescriptor(string symbol, bool isOperand, bool isOperator, bool isLeftParenthesis, bool isRightParenthesis, int precedence)
        {
            IsOperand = isOperand;
            IsOperator = isOperator;
            IsLeftParenthesis = isLeftParenthesis;
            IsRightParenthesis = isRightParenthesis;
            Precedence = precedence;
            _symbol = symbol;
        }

        public bool IsOperand { get; }

        public bool IsOperator { get; }

        public bool IsLeftParenthesis { get; }

        public bool IsRightParenthesis { get; }

        public int Precedence { get; }

        public override string ToString()
        {
            return _symbol;
        }
    }
}
