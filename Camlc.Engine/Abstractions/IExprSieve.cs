using System.Collections.Generic;

namespace Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface IExprSieve
    {
        IReadOnlyCollection<string> Sieve(string expr);
    }
}
