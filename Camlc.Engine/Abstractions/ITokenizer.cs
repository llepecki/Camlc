using Lepecki.Playground.Camlc.Engine.Tokens;

namespace Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface ITokenizer
    {
        IToken Create(TokenDescriptor tokenDescriptor);
    }
}
