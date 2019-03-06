using System;
using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    [Obsolete("This responsibility should probably be in the converter")]
    public class RpnExprBuilder
    {
        private readonly IList<Token> _tokens = new List<Token>();
        private readonly BinaryOperatorTokenFactory _binaryOperatorTokenFactory = new BinaryOperatorTokenFactory();

        public RpnExprBuilder Value(double value)
        {
            _tokens.Add(new OperandToken(value));
            return this;
        }

        public RpnExprBuilder Plus()
        {
            _tokens.Add(_binaryOperatorTokenFactory.Create("plus"));
            return this;
        }
        
        public RpnExpr Build()
        {
            throw new NotImplementedException();
        }
    }
}