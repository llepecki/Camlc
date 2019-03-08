using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions
{
    public interface IInfixToPostfixConverter
    {
        IReadOnlyCollection<string> Convert(IEnumerable<string> infixExpr);
    }
}