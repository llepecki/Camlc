using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions
{
    public interface IInfixToPostfixConverter
    {
        IEnumerable<string> Convert(IEnumerable<string> infixExpr);
    }
}