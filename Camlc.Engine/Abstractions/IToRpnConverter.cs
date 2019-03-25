namespace Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface IToRpnConverter
    {
        RpnExpr Convert(string expr);
    }
}
