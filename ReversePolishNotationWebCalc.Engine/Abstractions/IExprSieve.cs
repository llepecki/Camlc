using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions
{
    public interface IExprSieve
    {
        IReadOnlyCollection<string> Sieve(string expr);
    }
}
