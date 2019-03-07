using System;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class TokenFactory
    {
        private const string Plus = "plus";
        private const string Minus = "minus";
        private const string Multiply = "multiply";
        private const string Divide = "divide";

        public Token Create(string operation)
        {
            operation = operation.Trim().ToLower();

            switch (operation)
            {
                case Plus:
                    return new PlusOperatorToken();

                case Minus:
                    return new MinusOperatorToken();

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
