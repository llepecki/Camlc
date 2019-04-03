using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface IExprSieve
    {
        IReadOnlyCollection<string> Sieve(string expr);

        Task<IReadOnlyCollection<string>> SieveAsync(string expr, CancellationToken cancellationToken);
    }
}
