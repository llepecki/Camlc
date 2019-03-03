using System.Collections;
using System.Collections.Generic;

namespace ReversePolishNotationWebCalc.Engine
{
    public class RpnExpr : IEnumerable<Token>
    {
        private readonly IList<Token> _tokens = new List<Token>();

        public void Add(Token token)
        {
            _tokens.Add(token);
        }

        public IEnumerator<Token> GetEnumerator()
        {
            return _tokens.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}