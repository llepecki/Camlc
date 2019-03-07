namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions
{
    public interface IToRpnConverter
    {
        RpnExpr Convert(string expr);
    }
}
