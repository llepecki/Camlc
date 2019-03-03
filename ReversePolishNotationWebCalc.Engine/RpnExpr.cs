using System.Collections;
using System.Collections.Generic;

namespace ReversePolishNotationWebCalc.Engine
{
    public class RpnExpr : IEnumerable<Token>
    {
        public IEnumerator<Token> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}