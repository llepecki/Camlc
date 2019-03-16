using System.Collections.Generic;

namespace Lepecki.Playground.Camel.Engine.Abstractions
{
    public interface IExprSieve
    {
        IReadOnlyCollection<string> Sieve(string expr);
    }
}
