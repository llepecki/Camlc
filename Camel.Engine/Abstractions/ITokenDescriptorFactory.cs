namespace Lepecki.Playground.Camel.Engine.Abstractions
{
    public interface ITokenDescriptorFactory
    {
        TokenDescriptor Create(string symbol);
    }
}