namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions
{
    public interface ITokenDescriptorFactory
    {
        TokenDescriptor Create(string symbol);
    }
}