using System;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class TokenFactory
    {
        private const string Add = "add";
        private const string Subtract = "sub";
        private const string Multiply = "multiply";
        private const string Divide = "divide";

        public Token Create(string operation)
        {
            operation = operation.Trim().ToLower();

            switch (operation)
            {
                case Add:
                    return new AddOperatorToken();

                case Subtract:
                    return new SubtractOperatorToken();

                case Multiply:
                    return new MultiplyOperatorToken();

                case Divide:
                    return new DivideOperatorToken();

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
