namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public interface IToRpnConverter
    {
        RpnExpr Convert(string expr);
    }
}