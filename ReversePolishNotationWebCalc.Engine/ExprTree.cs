using System;
using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    [Obsolete("Remove", true)]
    public class ExprTree
    {
        private readonly TokenNode _root;

        public ExprTree(TokenNode root)
        {
            _root = root ?? throw new ArgumentNullException(nameof(root));
        }

        public IEnumerable<Token> TraverseInOrder()
        {
            throw new NotImplementedException();
        }
    }
}
