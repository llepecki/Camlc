using System.Collections.Generic;

namespace Lepecki.Playground.Camel.Engine.Abstractions
{
    public interface IInfixToPostfixConverter
    {
        IReadOnlyCollection<TokenDescriptor> Convert(IEnumerable<string> symbols);
    }
}
