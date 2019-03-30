namespace Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface ITokenDescriptorFactory
    {
        TokenDescriptor Create(string symbol);
    }
}
