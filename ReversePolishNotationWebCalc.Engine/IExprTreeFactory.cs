using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public interface IExprTreeFactory
    {
        ExprTree Build(IEnumerable<string> exprMembers);
    }
}