using System;

namespace ReversePolishNotationWebCalc.Engine
{
    public class BinaryOperatorTokenFactory
    {
        private const string Plus = "plus";
        private const string Minus = "minus";
        private const string Multiply = "multiply";
        private const string Divide = "divide";

        public OperatorToken Create(string operation)
        {
            operation = operation.Trim().ToLower();

            switch(operation)
            {
                case Plus:
                    return new BinaryOperatorToken((double a, double b) => a + b);

                case Minus:
                    return new BinaryOperatorToken((double a, double b) => a - b);

                case Multiply:
                    return new BinaryOperatorToken((double a, double b) => a * b);

                case Divide:
                    return new BinaryOperatorToken((double a, double b) => a / b);

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}