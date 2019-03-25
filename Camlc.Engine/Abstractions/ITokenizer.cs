using Lepecki.Playground.Camlc.Engine.Tokens;

namespace Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface ITokenizer
    {
        Token Create(TokenDescriptor tokenDescriptor);
    }
}
