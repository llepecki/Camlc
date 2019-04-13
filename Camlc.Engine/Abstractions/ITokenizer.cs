using Com.Lepecki.Playground.Camlc.Engine.Tokens;

namespace Com.Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface ITokenizer
    {
        Token Create(TokenDescriptor tokenDescriptor);
    }
}
