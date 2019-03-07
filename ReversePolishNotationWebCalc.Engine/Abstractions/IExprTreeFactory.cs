using System;
using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions
{
    [Obsolete("I probably won't be using a tree")]
    public interface IExprTreeFactory
    {
        ExprTree Build(IEnumerable<string> exprMembers);
    }
}
