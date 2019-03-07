namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions
{
    public interface ITokenizer
    {
        Token Create(string operandOrOperator);
    }
}
