using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.Camel.Engine
{
    public class RpnExpr : IEnumerable<Token>
    {
        private readonly Token[] _tokens;

        public RpnExpr(IEnumerable<Token> tokens)
        {
            if (tokens == null)
            {
                throw new ArgumentNullException(nameof(tokens));
            }

            _tokens = tokens.ToArray();
        }

        public IEnumerator<Token> GetEnumerator()
        {
            return _tokens.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

