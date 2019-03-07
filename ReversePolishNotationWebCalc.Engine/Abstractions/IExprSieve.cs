using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions
{
    public interface IExprSieve
    {
        IEnumerable<string> Sieve(string expr);
    }
}
