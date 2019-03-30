using System.Collections.Generic;

namespace Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface IInfixToPostfixConverter
    {
        IReadOnlyCollection<TokenDescriptor> Convert(IEnumerable<string> symbols);
    }
}
