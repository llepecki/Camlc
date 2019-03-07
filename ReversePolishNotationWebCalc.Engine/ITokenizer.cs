namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public interface ITokenizer
    {
        Token Create(string operandOrOperator);
    }
}
