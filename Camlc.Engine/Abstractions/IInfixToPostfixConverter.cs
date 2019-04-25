using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Com.Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface IInfixToPostfixConverter
    {
        IReadOnlyCollection<TokenDescriptor> Convert(IEnumerable<string> symbols);

        Task<IReadOnlyCollection<TokenDescriptor>> ConvertAsync(IEnumerable<string> symbols, CancellationToken cancellationToken);
    }
}
