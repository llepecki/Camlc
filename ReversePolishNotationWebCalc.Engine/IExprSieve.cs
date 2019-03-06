using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public interface IExprSieve
    {
        IEnumerable<string> Sieve(string expr);
    }
}