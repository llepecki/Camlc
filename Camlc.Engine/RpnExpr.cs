using Lepecki.Playground.Camlc.Engine.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.Camlc.Engine
{
    public class RpnExpr : IEnumerable<IToken>
    {
        private readonly IToken[] _tokens;

        public RpnExpr(IEnumerable<IToken> tokens)
        {
            if (tokens == null)
            {
                throw new ArgumentNullException(nameof(tokens));
            }

            _tokens = tokens.ToArray();
        }

        public IEnumerator<IToken> GetEnumerator()
        {
            return _tokens.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
