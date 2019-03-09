namespace Lepecki.Playground.Camel.Engine.Abstractions
{
    public interface IToRpnConverter
    {
        RpnExpr Convert(string expr);
    }
}
