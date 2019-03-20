using Lepecki.Playground.Camel.Engine.Tokens;

namespace Lepecki.Playground.Camel.Engine.Abstractions
{
    public interface ITokenizer
    {
        Token Create(TokenDescriptor tokenDescriptor);
    }
}
