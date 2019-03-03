using System;
using System.Collections.Generic;

namespace ReversePolishNotationWebCalc.Engine
{
    public class BinaryOperatorToken : OperatorToken
    {
        private readonly Func<double, double, double> _operation;

        public BinaryOperatorToken(Func<double, double, double> operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            _operation = operation;
        }

        public override int ArgCount => 2;

        public override double Calculate(double[] args)
        {
            if (args.Length == ArgCount)
            {
                return _operation(args[0], args[1]);
            }

            throw new ArgumentException("Binary operator only accepts two arguments", nameof(args));
        }
    }
}