namespace Lepecki.Playground.Camel.Engine.Abstractions
{
    public interface ITokenizer
    {
        Token Create(TokenDescriptor tokenDescriptor);
    }
}
