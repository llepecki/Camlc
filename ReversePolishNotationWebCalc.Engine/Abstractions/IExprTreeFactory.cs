using System;
using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions
{
    [Obsolete("Remove", true)]
    public interface IExprTreeFactory
    {
        ExprTree Build(IEnumerable<string> exprMembers);
    }
}
