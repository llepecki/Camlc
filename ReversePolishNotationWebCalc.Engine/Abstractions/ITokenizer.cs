namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions
{
    public interface ITokenizer
    {
        Token Create(TokenDescriptor tokenDescriptor);
    }
}
