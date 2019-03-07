using System;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class TokenNode
    {
        public TokenNode(Token token)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public Token Token { get; }

        public TokenNode Left { get; set; }

        public TokenNode Right { get; set; }
    }
}
